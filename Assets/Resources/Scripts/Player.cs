using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotHorSen = 7;

    private Rigidbody _rigidbody;
    private Light _flashlight;
    private float _rotY;
    private bool _isFlashlightOn = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _flashlight = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        var deltaZ = Input.GetAxis("Vertical") * speed;
        var deltaX = Input.GetAxis("Horizontal") * speed;

        var movement = transform.TransformDirection(
            Vector3.ClampMagnitude(new Vector3(deltaX, 0, deltaZ), speed) * Time.deltaTime
        );
            
        _rigidbody.MovePosition(_rigidbody.position + movement);
        
        _rotY += Input.GetAxis("Mouse X") * rotHorSen;
        transform.localEulerAngles = new Vector3(0, _rotY, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchFlashlight();
        }
    }

    private void SwitchFlashlight()
    {
        _isFlashlightOn = !_isFlashlightOn;
        _flashlight.enabled = _isFlashlightOn;
    }
}