using UnityEngine;

namespace Garden
{
    public class Cabinet: Collectable
    {
        public GameObject gun;
        
        protected override void Interact()
        {
            gun.SetActive(true);
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}