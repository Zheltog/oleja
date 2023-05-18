using UnityEngine;

public class MainController: MonoBehaviour
{
    public string configFileName = "Json/config";
    
    private void Start()
    {
        ConfigManager.Init(configFileName);
    }
}