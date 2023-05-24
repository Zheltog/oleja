using Common;
using UnityEngine;

namespace Menu
{
    public class MainController : MonoBehaviour
    {
        public string configFileName = "Json/menu";

        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
        }

        public void NewGame()
        {
            SceneLoader.LoadRoomStart();
        }

        public void Credits()
        {
            SceneLoader.LoadCredits();
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}