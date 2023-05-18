public class Exit : Item
{
    protected override void Interact()
    {
        PhaseControllerProxy.NextPhase();
    }
}