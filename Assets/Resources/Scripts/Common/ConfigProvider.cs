using UnityEngine;

namespace Common
{
    public static class ConfigProvider<T>
    {
        private static T _config;
        
        public static void Init(string configFilePath)
        {
            var jsonString = Resources.Load<TextAsset>(configFilePath)?.text;
            _config = JsonUtility.FromJson<T>(jsonString);
        }

        public static T GetConfig()
        {
            return _config;
        }
    }
}