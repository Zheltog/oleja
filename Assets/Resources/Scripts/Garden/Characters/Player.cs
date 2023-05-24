using UnityEngine;

namespace Garden
{
    public class Player : MonoBehaviour
    {
        public float squattingSpeed = 1.0f;
        public float calmSpeed = 2.0f;
        public float runningSpeed = 10.0f;
        public float rotHorSen = 7.0f;
        public float headMinY = 1.0f;
        public Transform head;

        private Rigidbody _rigidbody;
        private Light _flashlight;
        private float _currentRotY;
        private float _headMaxY;
        private bool _isFlashlightOn = true;
        private bool _isSquatting;
        private bool _isRunning;
        private float _currentSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _flashlight = GetComponentInChildren<Light>();
            _headMaxY = head.transform.localPosition.y;
            _currentRotY = transform.rotation.eulerAngles.y;
            _currentSpeed = calmSpeed;
        }

        private void Update()
        {
            if (Time.timeScale < 1)
            {
                return;
                // TODO: ?
            }

            var deltaZ = Input.GetAxis("Vertical") * _currentSpeed;
            var deltaX = Input.GetAxis("Horizontal") * _currentSpeed;

            var movement = transform.TransformDirection(
                Vector3.ClampMagnitude(new Vector3(deltaX, 0, deltaZ), _currentSpeed) * Time.deltaTime
            );

            _rigidbody.MovePosition(_rigidbody.position + movement);

            _currentRotY += Input.GetAxis("Mouse X") * rotHorSen;
            transform.localEulerAngles = new Vector3(0, _currentRotY, 0);

            ProcessFlashlightSwitch();
            ProcessSquatting();
            ProcessRunning();
        }

        private void ProcessFlashlightSwitch()
        {
            if (!Input.GetKeyDown(KeyCode.F))
            {
                return;
            }

            _isFlashlightOn = !_isFlashlightOn;
            _flashlight.enabled = _isFlashlightOn;
        }

        private void ProcessSquatting()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!_isSquatting && !_isRunning)
                {
                    _isSquatting = true;
                    _currentSpeed = squattingSpeed;
                    SitDown();
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                if (_isSquatting)
                {
                    _isSquatting = false;
                    _currentSpeed = calmSpeed;
                    StandUp();
                }
            }
        }

        private void ProcessRunning()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!_isRunning && !_isSquatting)
                {
                    _isRunning = true;
                    _currentSpeed = runningSpeed;
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (_isRunning)
                {
                    _isRunning = false;
                    _currentSpeed = calmSpeed;
                }
            }
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
}