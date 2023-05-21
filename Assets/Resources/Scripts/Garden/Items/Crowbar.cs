namespace Garden
{
    public class Crowbar : Item
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            PhaseControllerProxy.NextPhase();
            Destroy(gameObject);
        }
    }
}