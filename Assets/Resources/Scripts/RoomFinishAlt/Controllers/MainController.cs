using Common;
using UnityEngine;

namespace RoomFinishAlt
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "roomfinishalt";

        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
        }
    }
}