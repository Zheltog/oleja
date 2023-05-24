using Common;
using UnityEngine;

namespace Credits
{
    public class MainController : MonoBehaviour
    {
        public string configFileName = "Json/credits";
    
        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
        }

        public void Menu()
        {
            SceneLoader.LoadMenu();
        }
    }
}