using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    private List<string> _collectedItems = new List<string>();

    private void Start()
    {
        ItemsControllerProxy.Initialize(this);
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