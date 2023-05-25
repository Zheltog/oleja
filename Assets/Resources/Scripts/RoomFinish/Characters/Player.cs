using UnityEngine;

namespace RoomFinish
{
    public class Player : MonoBehaviour
    {
        public float speed = 2.0f;
        public float rotHorSen = 7.0f;
        
        private Rigidbody _rigidbody;
        private float _currentRotY;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentRotY = transform.rotation.eulerAngles.y;
        }
        
        private void Update()
        {
            var deltaZ = Input.GetAxis("Vertical") * speed;
            var deltaX = Input.GetAxis("Horizontal") * speed;
            
            var movement = transform.TransformDirection(
                Vector3.ClampMagnitude(new Vector3(deltaX, 0, deltaZ), speed) * Time.deltaTime
            );

            _rigidbody.MovePosition(_rigidbody.position + movement);

            _currentRotY += Input.GetAxis("Mouse X") * rotHorSen;
            transform.localEulerAngles = new Vector3(0, _currentRotY, 0);
        }
    }
}
