using UnityEngine;

namespace Common
{
    public class FootstepsAudioSource: MonoBehaviour
    {
        public float defaultPitch = 1f;
        public bool isChangeable = false;   // TODO
        
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _source.pitch = defaultPitch;
        }

        private void Update()
        {
            if (TimeStopper.IsTimeStopped && _source.enabled)
            {
                if (_source.isPlaying)
                {
                    _source.Pause();
                }
                _source.enabled = false;
            }

            if (!TimeStopper.IsTimeStopped && !_source.enabled)
            {
                _source.enabled = true;
            }
        }

        public void Disable()
        {
            _source.enabled = false;
        }

        public void Play()
        {
            if (!isChangeable)
            {
                return;
            }
            
            _source.Play();
        }
        
        public void Pause()
        {
            if (!isChangeable)
            {
                return;
            }
            
            _source.Pause();
        }

        public bool IsPlaying()
        {
            return _source.isPlaying;
        }

        public void IncreasePitch(float coefficient)
        {
            if (!isChangeable)
            {
                return;
            }
            
            _source.pitch = defaultPitch * coefficient;
            // footsteps.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / (defaultPitch * coefficient));
        }

        public void ResetPitch()
        {
            if (!isChangeable)
            {
                return;
            }
            
            _source.pitch = defaultPitch;
        }
    }
}