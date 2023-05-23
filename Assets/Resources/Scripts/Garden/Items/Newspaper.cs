namespace Garden
{
    public class Newspaper : Item
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
            Destroy(gameObject);
        }
    }
}