namespace Garden
{
    public class StudentId : Item
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
            Destroy(gameObject);
        }
    }
}