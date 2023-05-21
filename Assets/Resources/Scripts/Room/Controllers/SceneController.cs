using UnityEngine.SceneManagement;

namespace Room
{
    public static class SceneController
    {
        public static void LoadGarden()
        {
            SceneManager.LoadScene("Garden", LoadSceneMode.Single);
        }
    }
}