using System;
using System.Reflection;
using BepInEx.Bootstrap;

namespace DynamicMaps.ExternalModSupport
{
    // zzap: tells which version of a map this raid runs, so the matching map pack is shown.
    // MapVariants (LennoxP90) lets the player pick original/backport per raid; its public API is read by
    // reflection so DynamicMaps has no hard dependency. Without MapVariants a backport mod replaces its
    // map for every raid, so an installed Manimal map means "backport".
    public static class MapVariantsSupport
    {
        public const string Original = "original";
        public const string Backport = "backport";

        private static bool _initialized;
        private static PropertyInfo _currentVariant;
        private static PropertyInfo _currentLocationId;
        private static MethodInfo _isManaged;

        private static void Init()
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            if (!Chainloader.PluginInfos.TryGetValue("com.lennoxp90.mapvariants", out var info) || info.Instance == null)
            {
                return;
            }

            try
            {
                var api = info.Instance.GetType().Assembly.GetType("MapVariants.Client.Api.Maps");
                _currentVariant = api?.GetProperty("CurrentVariant", BindingFlags.Public | BindingFlags.Static);
                _currentLocationId = api?.GetProperty("CurrentLocationId", BindingFlags.Public | BindingFlags.Static);
                _isManaged = api?.GetMethod("IsManaged", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);
                Plugin.Log.LogInfo($"MapVariants found, variant API {(_currentVariant != null ? "ok" : "missing")}");
            }
            catch (Exception e)
            {
                Plugin.Log.LogWarning($"MapVariants found but its API could not be read: {e.Message}");
            }
        }

        // "original", "backport", a declared variant id (e.g. "halloween2026"), or null when unknown
        public static string GetVariant(string locationId)
        {
            Init();

            if (string.IsNullOrEmpty(locationId))
            {
                return null;
            }

            if (_currentVariant != null)
            {
                try
                {
                    var managed = _isManaged == null || (bool)_isManaged.Invoke(null, new object[] { locationId });
                    var variantLocation = _currentLocationId?.GetValue(null) as string;
                    var variant = _currentVariant.GetValue(null) as string;

                    if (managed && variant != null
                        && (variantLocation == null || string.Equals(variantLocation, locationId, StringComparison.OrdinalIgnoreCase)))
                    {
                        return variant;
                    }

                    if (managed)
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Plugin.Log.LogWarning($"MapVariants variant read failed: {e.Message}");
                }
            }

            return GetVariantWithoutMapVariants(locationId);
        }

        private static string GetVariantWithoutMapVariants(string locationId)
        {
            switch (locationId.ToLowerInvariant())
            {
                case "interchange":
                    return Chainloader.PluginInfos.ContainsKey("com.manimal.interchange") ? Backport : Original;
                case "lighthouse":
                    return Chainloader.PluginInfos.ContainsKey("com.manimal.lighthouse") ? Backport : Original;
                default:
                    return null;
            }
        }

        // a pack variant matches "original" or "backport"; every non-original variant is built on the backport
        public static bool Matches(string packVariant, string raidVariant)
        {
            if (string.IsNullOrEmpty(packVariant) || raidVariant == null)
            {
                return true;
            }

            if (string.Equals(packVariant, raidVariant, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            var raidIsOriginal = string.Equals(raidVariant, Original, StringComparison.OrdinalIgnoreCase);
            return string.Equals(packVariant, Backport, StringComparison.OrdinalIgnoreCase) && !raidIsOriginal;
        }
    }
}
