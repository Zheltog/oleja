namespace Garden
{
    public class Crowbar : Collectable
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            Destroy(gameObject);
        }
    }
}