using UnityEngine;

namespace Garden
{
    public static class ConfigManager
    {
        private static Config _config;
        
        public static void Init(string configFilePath)
        {
            var jsonString = Resources.Load<TextAsset>(configFilePath)?.text;
            _config = JsonUtility.FromJson<Config>(jsonString);
        }

        public static Config GetConfig()
        {
            return _config;
        }
    }
}