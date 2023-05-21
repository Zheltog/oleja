using UnityEngine;

namespace Room
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/room";
    
        private void Awake()
        {
            ConfigManager.Init(configFileName);
        }
    }
}