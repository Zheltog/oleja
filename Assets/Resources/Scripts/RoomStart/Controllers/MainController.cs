using UnityEngine;

namespace RoomStart
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomstart";
    
        private void Awake()
        {
            ConfigManager.Init(configFileName);
        }
    }
}