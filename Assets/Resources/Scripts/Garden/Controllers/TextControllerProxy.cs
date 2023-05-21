namespace Garden
{
    public static class TextControllerProxy
    {
        private static TextController _controller;

        public static void Initialize(TextController controller)
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

        public static void StartReading(string itemName)
        {
            _controller.StartReading(itemName);
        }
    }
}