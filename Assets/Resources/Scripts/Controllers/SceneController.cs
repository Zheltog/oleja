using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void LoadNext()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    
    public static void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}