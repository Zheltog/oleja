using UnityEngine.SceneManagement;

namespace Common
{
    public static class SceneController
    {
        public static void LoadMenu()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        
        public static void LoadRoomStart()
        {
            SceneManager.LoadScene("RoomStart", LoadSceneMode.Single);
        }
        
        public static void LoadGarden()
        {
            SceneManager.LoadScene("Garden", LoadSceneMode.Single);
        }
        
        public static void LoadRoomFinish()
        {
            SceneManager.LoadScene("RoomFinish", LoadSceneMode.Single);
        }
    
        public static void LoadGameOver()
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}