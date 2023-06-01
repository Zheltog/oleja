using UnityEngine;

namespace Garden
{
    public class Note : Collectable
    {
        public GameObject padlock;
        public Oleja oleja;
    
        protected override void Interact()
        {
            padlock.SetActive(true);
            oleja.AwakeOleja();
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}