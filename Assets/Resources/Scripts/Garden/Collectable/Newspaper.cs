namespace Garden
{
    public class Newspaper : Collectable
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}