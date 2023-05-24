using UnityEngine;

namespace RoomCommon
{
    public class AudioController: MonoBehaviour
    {
        public AudioSource textSoundSource;
        public string textSoundClipPath = "Audio/typewriter_key_press";
        public float pitchRangeMin = 0.7f;
        public float pitchRangeMax = 0.8f;
        
        private AudioClip _textSoundClip;
        
        private void Start()
        {
            _textSoundClip = Resources.Load<AudioClip>(textSoundClipPath);
        }
        
        public void PlayTextSound()
        {
            textSoundSource.Stop();
            textSoundSource.clip = _textSoundClip;
            textSoundSource.pitch = Random.Range(pitchRangeMin, pitchRangeMax);
            textSoundSource.Play();
        }
    }
}