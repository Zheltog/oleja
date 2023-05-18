public static class ReadingControllerProxy
{
    private static ReadingController _controller;

    public static void Initialize(ReadingController controller)
    {
        _controller = controller;
    }

    public static void ShowText(string itemName)
    {
        _controller.ShowText(itemName);
    }
}