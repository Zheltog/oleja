using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public float maxInteractionDistance = 1f;
    public bool requiresItemForInteraction;
    public string requiredItemName;
    public float playerFOV = 60f;   // TODO
    public Transform player;
    
    private bool _isAvailable;
    private bool _isInteracted;

    private void Update()
    {
        if (_isInteracted)
        {
            return;
        }

        if (Vector3.Distance(transform.position, player.position) > maxInteractionDistance)
        {
            ResetIsAvailable();
            return;
        }

        if (!IsInPlayerFov())
        {
            ResetIsAvailable();
            return;
        }

        if (requiresItemForInteraction && !CollectingControllerProxy.IsCollected(requiredItemName))
        {
            ResetIsAvailable();
            return;
        }

        if (!_isAvailable)
        {
            _isAvailable = true;
            TipControllerProxy.ShowTip(itemName);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _isInteracted = true;
            TipControllerProxy.HideTip(itemName);
            Interact();
        }
    }

    private bool IsInPlayerFov()
    {
        var pt = player.transform;
        var playerForward = pt.forward;
        var directionToItem = transform.position - pt.position;
        return Vector3.Angle(playerForward, directionToItem) < playerFOV / 2;
    }

    private void ResetIsAvailable()
    {
        if (_isAvailable)
        {
            _isAvailable = false;
            TipControllerProxy.HideTip(itemName);
        }
    }
    
    protected abstract void Interact();
}