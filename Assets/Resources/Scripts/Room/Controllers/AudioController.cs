using UnityEngine;

namespace Room
{
    public class AudioController: MonoBehaviour
    {
        public AudioSource textSoundSource;
        public string textSoundClipPath = "Audio/typewriter_key_press";
        
        private AudioClip _textSoundClip;
        
        private void Start()
        {
            _textSoundClip = Resources.Load<AudioClip>(textSoundClipPath);
        }
        
        public void PlayTextSound(float pitchRangeMin, float pitchRangeMax)
        {
            textSoundSource.Stop();
            textSoundSource.clip = _textSoundClip;
            textSoundSource.pitch = Random.Range(pitchRangeMin, pitchRangeMax);
            textSoundSource.Play();
        }
    }
}