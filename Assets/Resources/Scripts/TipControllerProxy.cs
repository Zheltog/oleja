public static class TipControllerProxy
{
    private static TipController _controller;

    public static void Initialize(TipController controller)
    {
        _controller = controller;
    }
    
    public static void ShowTip(string initiatorName)
    {
        _controller.ShowTip(initiatorName);
    }

    public static void HideTip(string initiatorName)
    {
        _controller.HideTip(initiatorName);
    }
}