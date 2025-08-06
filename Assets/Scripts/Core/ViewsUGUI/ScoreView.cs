using Core.Processors;
using TMPro;
using UnityEngine;
using Zenject;

namespace Core.ViewsUGUI
{
    public class ScoreView : MonoBehaviour
    {
        private const string Label = "Score: {0}";
        [SerializeField] private TextMeshProUGUI _textMesh;
        private ScoreProcessor _scoreProcessor;

        [Inject]
        private void Construct(ScoreProcessor scoreProcessor)
        {
            _scoreProcessor = scoreProcessor;
        }

        private void Awake()
        {
            UpdateLabel(0);
        }

        private void OnEnable()
        {
            _scoreProcessor.OnUpdate += UpdateLabel;
        }

        private void OnDisable()
        {
            _scoreProcessor.OnUpdate -= UpdateLabel;
        }

        private void UpdateLabel(int value)
        {
            _textMesh.text = string.Format(Label, value);
        }
    }   
}