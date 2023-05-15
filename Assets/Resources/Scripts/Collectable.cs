using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemName;
    public float maxTakingDistance = 1f;
    public Transform player;

    private Renderer _renderer;
    private bool _isAvailable;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer > maxTakingDistance)
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTipForCollectable(itemName);
            }
            return;
        }

        if (!_renderer.isVisible)
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTipForCollectable(itemName);
            }
            return;
        }
        
        // TODO: 'visible' even behind obstacles

        if (!_isAvailable)
        {
            _isAvailable = true;
            TipControllerProxy.ShowTipForCollectable(itemName);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(itemName + " taken");
            TipControllerProxy.HideTipForCollectable(itemName);
            Destroy(gameObject);
        }
    }
}