using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string requiredItemName;
    public float maxActionDistance = 1f;
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
        
        if (distanceToPlayer > maxActionDistance)
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTip(gameObject.name);
            }
            return;
        }

        if (!_renderer.isVisible)
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTip(gameObject.name);
            }
            return;
        }
        
        // TODO: 'visible' even behind obstacles

        var mayLeave = MayLeave();
        
        if (!_isAvailable)
        {
            _isAvailable = true;
            var tipType = mayLeave ? TipType.ExitAvailable : TipType.ExitUnavailable;
            TipControllerProxy.ShowTip(tipType, gameObject.name);
        }

        if (mayLeave && Input.GetKeyDown(KeyCode.E))
        {
            TipControllerProxy.HideTip(gameObject.name);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    private bool MayLeave()
    {
        return ItemsControllerProxy.IsCollected(requiredItemName);
    }
}