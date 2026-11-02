using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace DynamicMaps.Utils
{
    public enum ELanguage
    {
        Auto,
        Korean,
        English
    }

    // zzap: Korean/English switch. Auto follows the Windows display language.
    // Map texts (map names, layer names, labels, marker names) come from Lang/ko.json,
    // keyed by the English text, so map packs stay English and translations live in one file.
    public static class Lang
    {
        public static event Action OnChanged;

        public static bool IsKorean { get; private set; }

        private static Dictionary<string, string> _mapTextKo = new Dictionary<string, string>();

        public static void Init(ELanguage language)
        {
            Set(language);
            LoadMapTexts();
        }

        public static void Set(ELanguage language)
        {
            var isKorean = language == ELanguage.Korean
                || (language == ELanguage.Auto && IsWindowsKorean());

            if (isKorean == IsKorean)
            {
                return;
            }

            IsKorean = isKorean;
            OnChanged?.Invoke();
        }

        public static string T(string english, string korean)
        {
            return IsKorean ? korean : english;
        }

        // translates a text that came from a map pack, falls back to the English text
        public static string Map(string english)
        {
            if (!IsKorean || string.IsNullOrEmpty(english))
            {
                return english;
            }

            return _mapTextKo.TryGetValue(english, out var korean) ? korean : english;
        }

        private static bool IsWindowsKorean()
        {
            try
            {
                return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ko"
                    || CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ko";
            }
            catch
            {
                return false;
            }
        }

        private static void LoadMapTexts()
        {
            var path = Path.Combine(Plugin.Path, "Lang/ko.json");
            if (!File.Exists(path))
            {
                return;
            }

            try
            {
                var table = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
                if (table != null)
                {
                    _mapTextKo = new Dictionary<string, string>(table, StringComparer.OrdinalIgnoreCase);
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"Loading map translations failed from {path}: {e.Message}");
            }
        }
    }
}
