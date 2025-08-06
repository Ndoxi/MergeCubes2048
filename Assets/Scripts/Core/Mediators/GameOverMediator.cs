using Core.Data;
using Core.Observers;
using Core.ViewsUGUI;
using UnityEngine;
using Zenject;

namespace Core.Mediators
{
    public class GameOverMediator : MonoBehaviour
    {
        [SerializeField] private GameOverView _view;
        private IGameOverObserver _observer;

        [Inject]
        private void Construct(IGameOverObserver observer)
        {
            _observer = observer;
        }

        private void Awake()
        {
            _view.Hide();
        }

        private void OnEnable()
        {
            _observer.OnNotify += ShowView;
        }

        private void OnDisable()
        {
            _observer.OnNotify -= ShowView;
        }

        private void ShowView(GameOverData data)
        {
            _view.Show(data.score, data.totalPlaytime);
        }
    }
}