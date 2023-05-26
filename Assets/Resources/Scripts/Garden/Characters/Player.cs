using Common;
using UnityEngine;

namespace Garden
{
    public class Player : MonoBehaviour
    {
        public float squattingSpeed = 1.0f;
        public float calmSpeed = 2.0f;
        public float runningSpeed = 10.0f;
        public float rotHorSen = 7.0f;
        public AudioSource footsteps;

        private Rigidbody _rigidbody;
        private Animator _animator;
        private float _currentRotY;
        private bool _isSquatting;
        private bool _isRunning;
        private float _currentSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _currentRotY = transform.rotation.eulerAngles.y;
            _currentSpeed = calmSpeed;
        }

        private void Update()
        {
            if (TimeStopper.IsTimeStopped)
            {
                if (footsteps.isPlaying)
                {
                    footsteps.Pause();
                }
                return;
            }

            var deltaZ = Input.GetAxis("Vertical") * _currentSpeed;
            var deltaX = Input.GetAxis("Horizontal") * _currentSpeed;

            if ((deltaX != 0 || deltaZ < 0) && _isRunning)
            {
                StopRunning();
            }

            if (deltaX == 0 && deltaZ == 0)
            {
                footsteps.Pause();
            }
            else
            {
                if (!footsteps.isPlaying)
                {
                    footsteps.Play();
                }
            }

            var movement = transform.TransformDirection(
                Vector3.ClampMagnitude(new Vector3(deltaX, 0, deltaZ), _currentSpeed) * Time.deltaTime
            );

            _rigidbody.MovePosition(_rigidbody.position + movement);

            _currentRotY += Input.GetAxis("Mouse X") * rotHorSen;
            transform.localEulerAngles = new Vector3(0, _currentRotY, 0);

            ProcessSquatting();
            ProcessRunning();
        }

        private void ProcessSquatting()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (!_isSquatting && !_isRunning)
                {
                    _isSquatting = true;
                    _currentSpeed = squattingSpeed;
                    SitDown();
                    SetSquattingStepsSound();
                }
                return;
            }
            
            if (_isSquatting)
            {
                _isSquatting = false;
                _currentSpeed = calmSpeed;
                StandUp();
                SetCalmStepsSound();
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
                    SetRunningStepsSound();
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (_isRunning)
                {
                    StopRunning();
                }
            }
        }

        private void SetRunningStepsSound()
        {
            var coefficient = runningSpeed / calmSpeed;
            footsteps.pitch = coefficient;
            // footsteps.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / coefficient);
        }

        private void SetCalmStepsSound()
        {
            footsteps.pitch = 1;
        }

        private void SetSquattingStepsSound()
        {
            var coefficient = squattingSpeed / calmSpeed;
            footsteps.pitch = coefficient;
        }

        private void StopRunning()
        {
            _isRunning = false;
            _currentSpeed = calmSpeed;
            SetCalmStepsSound();
        }

        private void SitDown()
        {
            _animator.Play("SitDown", 0, 0);
        }

        private void StandUp()
        {
            _animator.Play("StandUp", 0, 0);
        }
    }
}