using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DynamicMaps.Data;
using DynamicMaps.ExternalModSupport;
using DynamicMaps.Utils;
using EFT.UI;
using UnityEngine;

namespace DynamicMaps.UI.Controls
{
    public class MapSelectDropdown : MonoBehaviour
    {
        private static readonly HashSet<string> AcceptableExtensions = new HashSet<string>{ "json", "jsonc" };

        public event Action<MapDef> OnMapSelected;
        public RectTransform RectTransform => gameObject.transform as RectTransform;

        private DropDownBox _dropdown;
        private readonly Dictionary<string, DateTime> _writeTimes = new Dictionary<string, DateTime>();
        private readonly Dictionary<string, MapDef> _mapDefs = new Dictionary<string, MapDef>();
        private List<MapDef> _selectableMapDefs;
        private string _nameFilter = null;

        public static MapSelectDropdown Create(GameObject prefab, Transform parent)
        {
            var go = GameObject.Instantiate(prefab);
            go.name = "MapSelectDropdown";

            var rectTransform = go.GetRectTransform();
            rectTransform.SetParent(parent);
            rectTransform.localScale = Vector3.one;

            var dropdown = go.AddComponent<MapSelectDropdown>();
            return dropdown;
        }

        private void Awake()
        {
            _dropdown = gameObject.GetComponentInChildren<DropDownBox>();
            _dropdown.SetLabelText(Lang.T("Select a Map", "지도 선택"));
        }

        private void OnSelectDropdownMap(int index)
        {
            OnMapSelected?.Invoke(_selectableMapDefs[index]);
        }

        private void ChangeAvailableMapDefs(IEnumerable<MapDef> mapDefs)
        {
            // check if these are the same map defs as before
            if (_selectableMapDefs != null && Enumerable.SequenceEqual(mapDefs, _selectableMapDefs))
            {
                return;
            }

            _selectableMapDefs = mapDefs.ToList();

            _dropdown.Show(_selectableMapDefs.Select(def => def.LocalizedName));

            // TODO: this references a BSG method of GInterface390
            _dropdown.OnValueChanged.Subscribe(OnSelectDropdownMap);

            gameObject.SetActive(_selectableMapDefs.Count > 1);
        }

        public void LoadMapDefsFromPath(string relPath)
        {
            var absolutePath = Path.Combine(Plugin.Path, relPath);
            var paths = Directory.EnumerateFiles(absolutePath, "*.*", SearchOption.AllDirectories)
                .Where(p => AcceptableExtensions.Contains(Path.GetExtension(p).TrimStart('.').ToLowerInvariant()));

            // NOTE: this will not catch deleted maps, which I'm fine with
            foreach (var path in paths)
            {
                var writeTime = File.GetLastWriteTimeUtc(path);
                if (_writeTimes.ContainsKey(path) && _writeTimes[path] == writeTime)
                {
                    // this is the same file as before
                    continue;
                }

                _writeTimes[path] = writeTime;

                Plugin.Log.LogInfo($"Trying to load MapDef from path: {path}");
                var mapDef = MapDef.LoadFromPath(path);
                if (mapDef != null)
                {
                    Plugin.Log.LogInfo($"Loaded MapDef with display name: {mapDef.DisplayName}");
                    _mapDefs[path] = mapDef;
                }
            }

            ChangeAvailableMapDefs(FilteredMapDefs());
        }

        private IEnumerable<MapDef> FilteredMapDefs()
        {
            if (string.IsNullOrEmpty(_nameFilter))
            {
                return _mapDefs.Values.OrderBy(m => m.LocalizedName);
            }

            // zzap: with a map swapped by MapVariants / a backport mod, show the pack made for this raid's version
            var byName = _mapDefs.Values.Where(m => m.MapInternalNames.Contains(_nameFilter)).ToList();
            var variant = MapVariantsSupport.GetVariant(_nameFilter);
            var byVariant = byName.Where(m => MapVariantsSupport.Matches(m.Variant, variant)).ToList();
            var candidates = byVariant.Count > 0 ? byVariant : byName;

            return candidates
                .OrderBy(m => VariantRank(m.Variant, variant))
                .ThenBy(m => m.LocalizedName);
        }

        // exact version first, then packs for any version; with the version unknown, the original map first
        private static int VariantRank(string packVariant, string raidVariant)
        {
            if (raidVariant != null && string.Equals(packVariant, raidVariant, StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(packVariant)
                || string.Equals(packVariant, MapVariantsSupport.Original, StringComparison.OrdinalIgnoreCase))
            {
                return raidVariant == null ? 0 : 1;
            }

            return 2;
        }

        public IEnumerable<MapDef> GetMapDefs()
        {
            return _mapDefs.Values;
        }

        public void LoadFirstAvailableMap()
        {
            if (_selectableMapDefs.Count  == 0)
            {
                return;
            }

            OnSelectDropdownMap(0);
        }

        public void FilterByInternalMapName(string internalMapName)
        {
            _nameFilter = internalMapName;
            if (FilteredMapDefs().FirstOrDefault() == null)
            {
                _nameFilter = "";
                Plugin.Log.LogWarning($"Cannot filter by {internalMapName}, no MapDefs match that map");
            }

            ChangeAvailableMapDefs(FilteredMapDefs());
        }

        public void ClearFilter()
        {
            _nameFilter = null;
            ChangeAvailableMapDefs(FilteredMapDefs());
        }

        public void OnLoadMap(MapDef mapDef)
        {
            _dropdown.UpdateValue(_selectableMapDefs.IndexOf(mapDef));
        }

        public bool IsDropdownOpen()
        {
            return _dropdown.CurrentState;
        }

        public void TryCloseDropdown()
        {
            _dropdown.Close();
        }
    }
}
