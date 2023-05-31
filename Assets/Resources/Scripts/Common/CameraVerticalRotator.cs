using UnityEngine;

namespace Common
{
    public class CameraVerticalRotator : MonoBehaviour
    {
        public float sensitivity = 7;
        public float minAngle = -60;
        public float maxAngle = 60;
    
        private float _rotationX;

        private void Update()
        {
            if (TimeStopper.IsTimeStopped)
            {
                return;
            }
        
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minAngle, maxAngle);
            transform.localEulerAngles = new Vector3(_rotationX, 0, 0); 
        }
    }

}