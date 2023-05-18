using System.Collections.Generic;
using UnityEngine;

public class CollectingController : MonoBehaviour
{
    private List<string> _collectedItems = new List<string>();

    private void Start()
    {
        CollectingControllerProxy.Initialize(this);
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