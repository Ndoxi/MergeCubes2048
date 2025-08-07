using Core.Infrastructure;
using System;
using UnityEngine;

namespace Core.Observers
{
    public class PlayBackgroundMusicObserver : IObserver
    {
        private readonly AudioPlayer _audioPlayer;
        private readonly AudioClip _clip;
        private readonly float _volume;

        public event Action OnNotify;

        public PlayBackgroundMusicObserver(AudioPlayer audioPlayer, AudioClip clip, float volume)
        {
            _audioPlayer = audioPlayer;
            _clip = clip;
            _volume = volume;
        }

        public void Notify()
        {
            _audioPlayer.PlayBackground(_clip, _volume);
            OnNotify?.Invoke();
        }
    }
}