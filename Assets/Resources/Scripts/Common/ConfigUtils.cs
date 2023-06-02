namespace Common
{
    public static class ConfigUtils
    {
        public static string ConfigFilesRoot => "Json";

        public static string GetConfigPath(string fileName)
        {
            return ConfigFilesRoot + "/" + LanguageInfoHolder.GetCurrentLanguage() + "/" + fileName;
        }
    }
}