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
        private IObserver _restartObserver;

        [Inject]
        private void Construct(IGameOverObserver observer, IObserver restartObserver)
        {
            _observer = observer;
            _restartObserver = restartObserver;
        }

        private void Awake()
        {
            HideView();
        }

        private void OnEnable()
        {
            _observer.OnNotify += ShowView;
            _restartObserver.OnNotify += HideView;
            _view.OnRestartButtonClick += Restart;
        }

        private void OnDisable()
        {
            _observer.OnNotify -= ShowView;
            _restartObserver.OnNotify -= HideView;
            _view.OnRestartButtonClick -= Restart;
        }

        private void ShowView(GameOverData data)
        {
            _view.Show(data.score, data.totalPlaytime);
        }

        private void Restart()
        {
            _restartObserver.Notify();
        }

        private void HideView()
        {
            _view.Hide();
        }
    }
}