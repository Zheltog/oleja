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

    public void ShowTip(string initiatorName)
    {
        if (_currentInitiator == initiatorName)
        {
            return;
        }
        
        _currentInitiator = initiatorName;

        var currentPhase = PhaseControllerProxy.CurrentPhase();

        switch (initiatorName)
        {
            case "Keys":
                tipText.text = "[E] Take the keys";
                break;
            case "Crowbar":
                if (currentPhase == Phase.Exploring)
                {
                    tipText.text = "[E] Take the crowbar";
                }
                break;
            case "Padlock":
                tipText.text = PhaseControllerProxy.CurrentPhase() == Phase.Escaping ?
                    "[E] Get outta here" : "It's locked...";
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