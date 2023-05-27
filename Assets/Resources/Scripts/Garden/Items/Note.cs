using UnityEngine;

namespace Garden
{
    public class Note : Item
    {
        public GameObject padlock;
        public Oleja oleja;
    
        protected override void Interact()
        {
            padlock.SetActive(true);
            oleja.AwakeOleja();
            CollectingControllerProxy.AddItem(gameObject.name);
            PhaseControllerProxy.NextPhase();
            TextControllerProxy.StartReading(gameObject.name);
        }
    }

}