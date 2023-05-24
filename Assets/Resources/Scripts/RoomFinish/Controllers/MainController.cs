using Common;
using UnityEngine;

namespace RoomFinish
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomfinish";
    
        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
        }
    }
}