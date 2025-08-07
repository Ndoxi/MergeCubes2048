using Core.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.ViewsUGUI
{
    public class GameOverView : MonoBehaviour
    {
        private const string ScoreLabel = "Total Score: {0}";
        private const string TimeLabel = "Total Playtime: {0}";

        public event Action OnRestartButtonClick;

        [SerializeField] private TextMeshProUGUI _scoreTextMesh;
        [SerializeField] private TextMeshProUGUI _timeTextMesh;
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Restart);
        }

        public void Show(int score, float playtime)
        {
            gameObject.SetActive(true);

            _scoreTextMesh.text = string.Format(ScoreLabel, score);
            var timeSpan = TimeSpan.FromSeconds(playtime);
            _timeTextMesh.text = string.Format(TimeLabel, $"{timeSpan.Minutes:D2}m {timeSpan.Seconds:D2}s");
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Restart()
        {
            OnRestartButtonClick?.Invoke();
        }
    }
}