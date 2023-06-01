using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public class CollectingController : MonoBehaviour
    {
        public string nothingItemName = "Nothing";
        
        private readonly List<string> _collectedItems = new();

        private void Start()
        {
            CollectingControllerProxy.Initialize(this);
            _collectedItems.Add(nothingItemName);
        }

        public void AddItem(string itemName)
        {
            _collectedItems.Add(itemName);
        }

        public bool IsCollected(string itemName)
        {
            return _collectedItems.Contains(itemName);
        }
    }
}