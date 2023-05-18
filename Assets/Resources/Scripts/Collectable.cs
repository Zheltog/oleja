using UnityEngine;

public class Collectable : Item
{
    protected override void Interact()
    {
        Debug.Log(itemName + " taken");
        CollectingControllerProxy.AddItem(itemName);
        Destroy(gameObject);
    }
}