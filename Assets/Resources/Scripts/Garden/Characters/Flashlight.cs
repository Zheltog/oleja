using Common;
using UnityEngine;

namespace Garden
{
    public class Flashlight: MonoBehaviour
    {
        public bool IsOn { get; private set; } = true;
        
        private Light _flashlight;

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

            IsOn = !IsOn;
            _flashlight.enabled = IsOn;
        }
    }
}