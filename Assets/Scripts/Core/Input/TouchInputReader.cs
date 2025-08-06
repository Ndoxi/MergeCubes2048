using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Input
{
    public class TouchInputReader : MonoBehaviour, IInputReader, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action LaunchAction;
        public event Action<float> MoveAction;

        [SerializeField] private float _sensativity = 1;

        private bool _isDragging = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDragging) 
                return;

            var delta = eventData.delta.x;
            MoveAction?.Invoke(delta * _sensativity);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isDragging) 
                return;

            _isDragging = false;
            LaunchAction?.Invoke();
        }
    }
}