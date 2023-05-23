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

        public void Exit()
        {
            Application.Quit();
        }
    }
}