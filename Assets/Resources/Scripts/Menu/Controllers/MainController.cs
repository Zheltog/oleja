using Common;
using UnityEngine;

namespace Menu
{
    public class MainController : MonoBehaviour
    {
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