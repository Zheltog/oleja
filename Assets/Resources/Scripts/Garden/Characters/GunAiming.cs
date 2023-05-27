using Common;
using UnityEngine;

namespace Garden
{
    public class GunAiming: MonoBehaviour
    {
        private Animator _animator;
        private bool _isAiming;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (TimeStopper.IsTimeStopped)
            {
                if (_isAiming)
                {
                    _animator.Play("Reaiming", 0, 0);
                    _isAiming = false;
                }
                return;
            }
            
            
            if (Input.GetMouseButtonDown(1) && !_isAiming)
            {
                _animator.Play("Aiming", 0, 0);
                _isAiming = true;
            }

            if (Input.GetMouseButtonUp(1) && _isAiming)
            {
                _animator.Play("Reaiming", 0, 0);
                _isAiming = false;
            }
        }
    }
}