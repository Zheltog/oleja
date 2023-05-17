using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string requiredItemName;
    public float maxActionDistance = 1f;
    public Transform player;
    
    private bool _isAvailable;

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

        if (!IsInPlayerFov())
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                TipControllerProxy.HideTip(gameObject.name);
            }
            return;
        }

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

    private bool IsInPlayerFov()
    {
        var pt = player.transform;
        var playerForward = pt.forward;
        var directionToMe = transform.position - pt.position;
        return Vector3.Angle(playerForward, directionToMe) < 60 / 2;    // TODO
    }

    private bool MayLeave()
    {
        return ItemsControllerProxy.IsCollected(requiredItemName);
    }
}