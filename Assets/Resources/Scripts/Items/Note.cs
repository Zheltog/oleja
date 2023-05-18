using UnityEngine;

public class Note : Item
{
    public GameObject padlock;
    
    protected override void Interact()
    {
        padlock.SetActive(true);
        CollectingControllerProxy.AddItem(gameObject.name);
        PhaseControllerProxy.NextPhase();
        TextControllerProxy.StartReading(gameObject.name);
        Destroy(gameObject);
    }
}
