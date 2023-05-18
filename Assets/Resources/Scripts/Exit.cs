using UnityEngine.SceneManagement;

public class Exit : Item
{
    protected override void Interact()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}