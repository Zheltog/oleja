using UnityEngine;

namespace RoomFinish
{
    public class Rug : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            MainControllerProxy.ToBeContinued();
        }
    }
}