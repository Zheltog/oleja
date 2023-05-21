namespace Garden
{
    public class Padlock : Item
    {
        protected override void Interact()
        {
            PhaseControllerProxy.NextPhase();
        }
    }
}