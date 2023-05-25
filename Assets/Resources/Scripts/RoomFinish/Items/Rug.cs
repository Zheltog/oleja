using UnityEngine;

namespace RoomFinish
{
    class Rug : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            MainControllerProxy.ToBeContinued();
        }
    }
}