using UnityEngine;

namespace Garden
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/garden";
    
        private void Awake()
        {
            ConfigManager.Init(configFileName);
        }
    }
}