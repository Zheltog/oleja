using Common;
using UnityEngine;

namespace Garden
{
    public class GunBullet : MonoBehaviour
    {
        // TODO: shoots through walls...
        // TODO: Oleja's collider is large cube...
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Oleja>(out Oleja _))
            {
                SceneLoader.LoadCredits();
            }
        }
    }
}