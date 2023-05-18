public class Note : Item
{
    protected override void Interact()
    {
        CollectingControllerProxy.AddItem(gameObject.name);
        PhaseControllerProxy.NextPhase();
        ReadingControllerProxy.ShowText(gameObject.name);
        Destroy(gameObject);
    }
}
