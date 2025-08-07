using UnityEngine;

[CreateAssetMenu(fileName = "CubeVFX", menuName = "Scriptable Objects/CubeVFX")]
public class CubeVFX : ScriptableObject
{
    public AudioClip soundClip;
    public float soundVolume = 1f;
    public float animationDuration = 0.3f;
    //public Ease animationEase = Ease.OutBack;
    public Vector3 punchScaleMultiplier = Vector3.one;
}
