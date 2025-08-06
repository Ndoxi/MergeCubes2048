using Core.Data;
using System;
using TMPro;
using UnityEngine;

namespace Core.ViewsUGUI
{
    public class GameOverView : MonoBehaviour
    {
        private const string ScoreLabel = "Total Score: {0}";
        private const string TimeLabel = "Total Playtime: {0}";

        [SerializeField] private TextMeshProUGUI _scoreTextMesh;
        [SerializeField] private TextMeshProUGUI _timeTextMesh;

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
    }
}