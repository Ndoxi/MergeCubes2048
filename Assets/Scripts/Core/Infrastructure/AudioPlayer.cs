using UnityEngine;

namespace Core.Infrastructure
{
    public class AudioPlayer
    {
        private bool _initialized;
        private AudioSource _audioSource;

        public void Init()
        {
            if (_initialized)
                return;

            var audioSource = CreateAudioSource("UniversalAudioPlayer");
            UnityEngine.Object.DontDestroyOnLoad(audioSource.gameObject);
            _audioSource = audioSource;

            _initialized = true;
        }

        public void PlayEffect(AudioClip clip, float volume)
        {
            _audioSource.PlayOneShot(clip, volume);
        }

        public void PlayBackground(AudioClip clip, float volume)
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.volume = volume;
            _audioSource.Play();
        }

        private AudioSource CreateAudioSource(string name)
        {
            var go = new GameObject(name);
            return go.AddComponent<AudioSource>();
        }
    }
}