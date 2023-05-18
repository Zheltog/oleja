using UnityEngine;

public class MainController: MonoBehaviour
{
    public string configFileName = "Json/config";
    
    private void Awake()
    {
        ConfigManager.Init(configFileName);
    }
}