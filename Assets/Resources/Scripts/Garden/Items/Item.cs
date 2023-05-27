using UnityEngine;

namespace Garden
{
    public abstract class Item : MonoBehaviour
    {
        public bool requiresItemForInteraction;
        public string requiredItemName;

        private bool _isAvailable;
        private bool _isInteracted;

        private void Update()
        {
            if (_isInteracted)
            {
                return;
            }

            if (_isAvailable && Input.GetKeyDown(KeyCode.E))
            {
                if (requiresItemForInteraction && !CollectingControllerProxy.IsCollected(requiredItemName))
                {
                    return;
                }

                _isInteracted = true;
                TextControllerProxy.HideTip(gameObject.name);
                Interact();
            }
        }

        public void SetAvailable()
        {
            if (_isInteracted)
            {
                return;
            }
            
            _isAvailable = true;
            TextControllerProxy.ShowTip(gameObject.name);
        }

        public void SetUnavailable()
        {
            _isAvailable = false;
            TextControllerProxy.HideTip(gameObject.name);
        }

        protected abstract void Interact();
    }
}