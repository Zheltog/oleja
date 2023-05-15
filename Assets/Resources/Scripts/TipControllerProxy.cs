public static class TipControllerProxy
{
    private static TipController _controller;

    public static void Initialize(TipController controller)
    {
        _controller = controller;
    }
    
    public static void ShowTipForCollectable(string itemName)
    {
        _controller.ShowTipForCollectable(itemName);
    }

    public static void HideTipForCollectable(string itemName)
    {
        _controller.HideTipForCollectable(itemName);
    }
}