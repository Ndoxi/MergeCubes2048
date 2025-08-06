using Core.Processors;
using TMPro;
using UnityEngine;
using Zenject;

namespace Core.ViewsUGUI
{
    public class TimeView : MonoBehaviour
    {
        private const string Label = "Time: {0}";
        [SerializeField] private TextMeshProUGUI _textMesh;
        private TimeProcessor _timeProcessor;

        [Inject]
        private void Construct(TimeProcessor timeProcessor)
        {
            _timeProcessor = timeProcessor;
        }

        private void Awake()
        {
            UpdateLabel(0);
        }

        private void OnEnable()
        {
            _timeProcessor.OnUpdate += UpdateLabel;
        }

        private void OnDisable()
        {
            _timeProcessor.OnUpdate -= UpdateLabel;
        }

        private void UpdateLabel(int value)
        {
            _textMesh.text = string.Format(Label, value);
        }
    }
}