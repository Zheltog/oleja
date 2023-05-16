using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotHorSen = 7.0f;
    public float headMinY = 1.0f;
    public Transform head;
    public Rigidbody legs;

    private Light _flashlight;
    private float _rotY;
    private float _headMaxY;
    private bool _isFlashlightOn = true;
    private bool _isSquatting = false;

    private void Start()
    {
        _flashlight = GetComponentInChildren<Light>();
        _headMaxY = head.localPosition.y;
        Debug.Log("HEAD ON: " + _headMaxY);
    }

    private void Update()
    {
        var deltaZ = Input.GetAxis("Vertical") * speed;
        var deltaX = Input.GetAxis("Horizontal") * speed;

        var movement = transform.TransformDirection(
            Vector3.ClampMagnitude(new Vector3(deltaX, 0, deltaZ), speed) * Time.deltaTime
        );
            
        legs.MovePosition(legs.position + movement);
        
        _rotY += Input.GetAxis("Mouse X") * rotHorSen;
        transform.localEulerAngles = new Vector3(0, _rotY, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchFlashlight();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!_isSquatting)
            {
                _isSquatting = true;
                SitDown();
            }
            else
            {
                _isSquatting = false;
                StandUp();
            }
        }
    }

    private void SwitchFlashlight()
    {
        _isFlashlightOn = !_isFlashlightOn;
        _flashlight.enabled = _isFlashlightOn;
    }

    private void SitDown()
    {
        var headPosition = head.localPosition;
        head.localPosition = new Vector3(headPosition.x, headMinY, headPosition.z);
    }
    
    private void StandUp()
    {
        var headPosition = head.localPosition;
        head.localPosition = new Vector3(headPosition.x, _headMaxY, headPosition.z);
    }
}