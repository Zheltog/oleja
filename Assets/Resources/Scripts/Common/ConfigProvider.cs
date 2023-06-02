using UnityEngine;

namespace Common
{
    public static class ConfigProvider<T>
    {
        private static T _config;
        
        public static void Init(string configFileName)
        {
            var jsonString = Resources.Load<TextAsset>(ConfigUtils.GetConfigPath(configFileName))?.text;
            _config = JsonUtility.FromJson<T>(jsonString);
        }
        
        public static void Init(string configFileRoot, string configFileName)
        {
            var jsonString = Resources.Load<TextAsset>(configFileRoot + "/" + configFileName)?.text;
            _config = JsonUtility.FromJson<T>(jsonString);
        }

        public static T GetConfig()
        {
            return _config;
        }
    }
}