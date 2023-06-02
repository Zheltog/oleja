using System.Collections.Generic;

namespace Common
{
    public static class LanguageInfoHolder
    {
        private const string ConfigFileName = "languages";
        private static LanguagesConfig _config;
        private static int _currentLanguageIndex = -1;

        public static bool IsInitialized()
        {
            return _currentLanguageIndex != -1;
        }

        public static void Initialize()
        {
            ConfigProvider<LanguagesConfig>.Init(ConfigUtils.ConfigFilesRoot, ConfigFileName);
            _config = ConfigProvider<LanguagesConfig>.GetConfig();
            SetCurrentLanguageIndex(_config.defaultLanguageIndex);
        }
        
        public static List<string> GetAvailableLanguages()
        {
            return _config.languages;
        }

        public static string GetCurrentLanguage()
        {
            return _config.languages[_currentLanguageIndex];
        }

        public static int GetCurrentLanguageIndex()
        {
            return _currentLanguageIndex;
        }

        public static void SetCurrentLanguageIndex(int index)
        {
            _currentLanguageIndex = index;
        }
    }
}