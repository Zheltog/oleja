using TMPro;
using UnityEngine;

public class ReadingController : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI text;

    private bool _isShown;

    private void Start()
    {
        ReadingControllerProxy.Initialize(this);
    }

    private void Update()
    {
        if (_isShown && Input.GetKeyDown(KeyCode.Escape))
        {
            HideText();
        }
    }

    public void ShowText(string itemName)
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        text.text = itemName;
        _isShown = true;
    }

    private void HideText()
    {
        text.text = "";
        panel.SetActive(false);
        _isShown = false;
        Time.timeScale = 1;
    }
}