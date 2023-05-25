using UnityEngine;

namespace Garden
{
    public class InteractionZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Item>(out Item item))
            {
                item.SetAvailable();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Item>(out Item item))
            {
                item.SetUnavailable();
            }
        }
    }
}
