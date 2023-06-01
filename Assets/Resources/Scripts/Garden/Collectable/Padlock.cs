using Common;

namespace Garden
{
    public class Padlock : Collectable
    {
        protected override void Interact()
        {
            SceneLoader.LoadRoomFinish();
        }
    }
}