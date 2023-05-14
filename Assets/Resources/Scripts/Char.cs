using UnityEngine;

public class Char : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotHorSen = 7;

    private Rigidbody _rigidbody;
    private float _rotY;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
    }
}