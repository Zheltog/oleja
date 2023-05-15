public static class ItemsControllerProxy
{
    private static ItemsController _controller;

    public static void Initialize(ItemsController controller)
    {
        _controller = controller;
    }
    
    public static void AddItem(string itemName)
    {
        _controller.AddItem(itemName);
    }

    public static void RemoveItem(string itemName)
    {
        _controller.RemoveItem(itemName);
    }

    public static bool IsCollected(string itemName)
    {
        return _controller.IsCollected(itemName);
    }
}
