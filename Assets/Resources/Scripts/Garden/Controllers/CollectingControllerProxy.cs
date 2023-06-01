namespace Garden
{
    public static class CollectingControllerProxy
    {
        private static CollectingController _controller;

        public static void Initialize(CollectingController controller)
        {
            _controller = controller;
        }
    
        public static void AddItem(string itemName)
        {
            _controller.AddItem(itemName);
        }

        public static bool IsCollected(string itemName)
        {
            return _controller.IsCollected(itemName);
        }
    }
}