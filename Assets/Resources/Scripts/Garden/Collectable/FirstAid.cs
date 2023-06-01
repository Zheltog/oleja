using UnityEngine;

namespace Garden
{
    public class FirstAid: Collectable
    {
        public Animator handsAnimator;
        
        protected override void Interact()
        {
            handsAnimator.Play("HandsCalm", 0, 0);
            CollectingControllerProxy.AddItem(gameObject.name);
            TextControllerProxy.StartReading(gameObject.name);
        }
    }
}