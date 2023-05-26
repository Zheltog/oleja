using Common;
using UnityEngine;

namespace Garden
{
    public class Flashlight: MonoBehaviour
    {
        private Light _flashlight;
        private bool _isFlashlightOn = true;

        private void Start()
        {
            _flashlight = GetComponent<Light>();
        }

        private void Update()
        {
            if (TimeStopper.IsTimeStopped)
            {
                return;
            }
            
            if (!Input.GetKeyDown(KeyCode.F))
            {
                return;
            }

            _isFlashlightOn = !_isFlashlightOn;
            _flashlight.enabled = _isFlashlightOn;
        }
    }
}