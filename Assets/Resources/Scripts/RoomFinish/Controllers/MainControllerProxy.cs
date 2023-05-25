namespace RoomFinish
{
    public static class MainControllerProxy
    {
        private static MainController _controller;
        
        public static void Init(MainController controller)
        {
            _controller = controller;
        }
        
        public static void StopTyping()
        {
            _controller.StopTyping();
        }

        public static void ToBeContinued()
        {
            _controller.ToBeContinued();
        }
    }
}