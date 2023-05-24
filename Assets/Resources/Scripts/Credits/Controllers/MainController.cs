using Common;
using UnityEngine;

namespace Credits
{
    public class MainController : MonoBehaviour
    {
        public string configFileName = "Json/credits";
    
        private void Awake()
        {
            ConfigManager.Init(configFileName);
        }

        public void Menu()
        {
            SceneController.LoadMenu();
        }
    }
}
