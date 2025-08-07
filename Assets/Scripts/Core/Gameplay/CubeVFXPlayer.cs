using Core.Infrastructure;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Core.Gameplay
{
    public class CubeVFXPlayer : MonoBehaviour
    {
        [SerializeField] private CubeView _cubeView;
        [SerializeField] private CubeVFX _launchVFX;
        [SerializeField] private CubeVFX _mergeVFX;
        private AudioPlayer _audioPlayer;

        [Inject]
        private void Construct(AudioPlayer audioPlayer)
        {
            _audioPlayer = audioPlayer;
        }

        public void OnLaunch()
        {
            Play(_launchVFX);
        }

        public void OnMerge()
        {
            Play(_mergeVFX);
        }

        private void Play(CubeVFX vfx)
        {
            _audioPlayer.PlayEffect(vfx.soundClip, vfx.soundVolume);

            var target = _cubeView.transform;
            DOTween.Complete(target);
            target.DOPunchScale(vfx.punchScaleMultiplier, vfx.animationDuration)
                  .SetEase(vfx.animationEase);
        }
    }
}