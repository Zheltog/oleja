using Common;
using UnityEngine;

namespace Credits
{
    public class MainController : MonoBehaviour
    {
        public string configFileName = "credits";
    
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