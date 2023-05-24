using Common;
using UnityEngine;

namespace RoomStart
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomstart";
    
        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
        }
    }
}