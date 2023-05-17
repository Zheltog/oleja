using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemName;
    public float maxTakingDistance = 1f;
    public Transform player;

    private bool _isAvailable;

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer > maxTakingDistance)
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTip(itemName);
            }
            return;
        }

        if (!IsInPlayerFov())
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTip(itemName);
            }
            return;
        }

        if (!_isAvailable)
        {
            _isAvailable = true;
            TipControllerProxy.ShowTip(TipType.Collect, itemName);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(itemName + " taken");
            ItemsControllerProxy.AddItem(itemName);
            TipControllerProxy.HideTip(itemName);
            Destroy(gameObject);
        }
    }
    
    private bool IsInPlayerFov()
    {
        var pt = player.transform;
        var playerForward = pt.forward;
        var directionToMe = transform.position - pt.position;
        return Vector3.Angle(playerForward, directionToMe) < 60 / 2;    // TODO
    }
}