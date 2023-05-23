using Common;
using UnityEngine;

namespace Menu
{
    public class MainController : MonoBehaviour
    {
        public void NewGame()
        {
            SceneController.LoadRoomStart();
        }

        public void Credits()
        {
            SceneController.LoadCredits();
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}