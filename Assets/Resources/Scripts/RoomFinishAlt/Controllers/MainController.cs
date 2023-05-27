using Common;
using UnityEngine;

namespace RoomFinishAlt
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomfinishalt";

        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
        }
    }
}