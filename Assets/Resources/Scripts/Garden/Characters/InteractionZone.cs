using UnityEngine;

namespace Garden
{
    public class InteractionZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Collectable>(out var item))
            {
                item.SetAvailable();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Collectable>(out var item))
            {
                item.SetUnavailable();
            }
        }
    }
}
