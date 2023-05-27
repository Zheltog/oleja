using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class CollectingController : MonoBehaviour
    {
        public string nothingItemName = "Nothing";
        
        private List<string> _collectedItems = new List<string>();

        private void Start()
        {
            CollectingControllerProxy.Initialize(this);
            _collectedItems.Add(nothingItemName);
        }

        public void AddItem(string itemName)
        {
            _collectedItems.Add(itemName);
        }

        public void RemoveItem(string itemName)
        {
            _collectedItems.Remove(itemName);
        }

        public bool IsCollected(string itemName)
        {
            return _collectedItems.Contains(itemName);
        }
    }
}