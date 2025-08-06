using Core.Data;
using TMPro;
using UnityEngine;

namespace Core.Gameplay
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private TextMeshPro[] _textMeshes;
        private CubeColorsData _colorsData;

        public void Init(int value)
        {
            _meshRenderer.material.color = _colorsData.GetColorForValue(value);

            var valueStringified = value.ToString();
            foreach (var textMesh in _textMeshes)
                textMesh.text = valueStringified;
        }
    }
}