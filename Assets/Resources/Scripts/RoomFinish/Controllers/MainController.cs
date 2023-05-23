using UnityEngine;

namespace RoomFinish
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomfinish";
    
        private void Awake()
        {
            ConfigManager.Init(configFileName);
        }
    }
}