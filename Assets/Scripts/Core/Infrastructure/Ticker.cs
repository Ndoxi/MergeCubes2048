using System;
using UnityEngine;

namespace Core.Infrastructure
{
    public class Ticker : MonoBehaviour, ITickService
    {
        public event Action<float> OnTick;

        private void Update()
        {
            OnTick?.Invoke(Time.deltaTime);
        }
    }
}