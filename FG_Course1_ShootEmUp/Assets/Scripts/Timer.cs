using UnityEngine;
using UnityEngine.Events;

namespace ShootEmUp
{
    public class Timer : MonoBehaviour
    {
        //public UnityEvent onTimerBegin;
        public UnityEvent<float> onTimerChanged;
        public UnityEvent<float> onTimerChangedInverse;
        public UnityEvent onTimerCompleted;

        private float timerDuration = 0.0f;
        private float timeLeft = 0.0f;
        private float timePercent = 0.0f;

        private void Awake()
        {
            enabled = false;
        }

        public void StartTimer(float duration)
        {
            timerDuration = duration;
            timeLeft = duration;
            enabled = true;
            //onTimerBegin.Invoke();
        }

        private void Update()
        {
            timeLeft -= Time.deltaTime;
            timePercent = timeLeft / timerDuration;
            onTimerChanged.Invoke(timePercent);
            onTimerChangedInverse.Invoke(1.0f - timePercent);

            if (timeLeft <= float.Epsilon)
            {
                enabled = false;
                onTimerCompleted.Invoke();
            }
        }
    }
}