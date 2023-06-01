namespace Garden
{
    public class Smartphone : Collectable
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}