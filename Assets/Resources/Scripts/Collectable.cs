using UnityEngine;

public class Collectable : Item
{
    protected override void Interact()
    {
        Debug.Log(itemName + " taken");
        CollectingControllerProxy.AddItem(itemName);
        PhaseControllerProxy.NextPhase();
        Destroy(gameObject);
    }
}