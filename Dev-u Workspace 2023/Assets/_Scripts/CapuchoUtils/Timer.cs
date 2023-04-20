
using System;

namespace CapuchoUtils
{
    public class Timer
    {
        public float RemainingSeconds { get; private set; }

        public event Action OnTimerEnd;
        public Timer (float duration) 
        {
            RemainingSeconds = duration;
        }

        public void Tick(float deltaTime) 
        {
            if (RemainingSeconds <= 0f)
                return;

            RemainingSeconds -= deltaTime;
            CheckTimerEnd();
        }

        private void CheckTimerEnd()
        {
            if (RemainingSeconds > 0f)
                return;

            RemainingSeconds = 0f;
            OnTimerEnd?.Invoke();
        }
    }

}
