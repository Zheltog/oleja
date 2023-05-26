using UnityEngine;

namespace RoomFinish
{
    public class CameraVerticalRotator: MonoBehaviour
    {
        public float sensitivity = 7;
        public float minAngle = -60;
        public float maxAngle = 80;
    
        private float _rotationX;

        private void Update()
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minAngle, maxAngle);
            transform.localEulerAngles = new Vector3(_rotationX, 0, 0); 
        }
    }
}