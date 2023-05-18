public static class PhaseControllerProxy
{
    private static PhaseController _controller;
    
    public static void Initialize(PhaseController controller)
    {
        _controller = controller;
    }
    
    public static Phase CurrentPhase()
    {
        return _controller.CurrentPhase();
    }

    public static void NextPhase()
    {
        _controller.NextPhase();
    }
}