namespace Garden
{
    public class StudentId : Collectable
    {
        protected override void Interact()
        {
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}