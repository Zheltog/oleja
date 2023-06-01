namespace Garden
{
    public class Bag: Collectable
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}