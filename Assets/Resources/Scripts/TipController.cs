using TMPro;
using UnityEngine;

public class TipController: MonoBehaviour
{
    public TextMeshProUGUI tipText;

    private string _currentCollectable = "";

    private void Start()
    {
        TipControllerProxy.Initialize(this);
    }

    public void ShowTipForCollectable(string itemName)
    {
        if (_currentCollectable == itemName)
        {
            return;
        }
        
        _currentCollectable = itemName;
        tipText.text = "Press [E] to take '" + _currentCollectable + "'";
    }

    public void HideTipForCollectable(string itemName)
    {
        if (_currentCollectable != itemName)
        {
            return;
        }

        _currentCollectable = null;
        tipText.text = "";
    }
}