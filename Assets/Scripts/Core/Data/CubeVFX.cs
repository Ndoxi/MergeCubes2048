using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "CubeVFX", menuName = "Scriptable Objects/CubeVFX")]
public class CubeVFX : ScriptableObject
{
    public AudioClip soundClip => _soundClip;
    public float soundVolume => _soundVolume;
    public float animationDuration => _animationDuration;
    public Ease animationEase => _animationEase;
    public Vector3 punchScaleMultiplier => _punchScaleMultiplier;    
    
    [SerializeField] private AudioClip _soundClip;
    [SerializeField] private float _soundVolume = 1f;
    [SerializeField] private float _animationDuration = 0.3f;
    [SerializeField] private Ease _animationEase = Ease.OutBack;
    [SerializeField] private Vector3 _punchScaleMultiplier = Vector3.one;
}
