using TMPro;
using UnityEngine;

public class TipController: MonoBehaviour
{
    public TextMeshProUGUI tipText;

    private string _currentInitiator = "";

    private void Start()
    {
        TipControllerProxy.Initialize(this);
    }

    public void ShowTip(TipType type, string initiatorName)
    {
        if (_currentInitiator == initiatorName)
        {
            return;
        }
        
        _currentInitiator = initiatorName;

        switch (type)
        {
            case TipType.Collect:
                tipText.text = "Press [E] to take '" + initiatorName + "'";
                break;
            case TipType.ExitUnavailable:
                tipText.text = "It's locked...";
                break;
            case TipType.ExitAvailable:
                tipText.text = "Press [E] to get outta here!";
                break;
        }
    }

    public void HideTip(string itemName)
    {
        if (_currentInitiator != itemName)
        {
            return;
        }

        _currentInitiator = null;
        tipText.text = "";
    }
}