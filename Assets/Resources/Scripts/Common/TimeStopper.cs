using UnityEngine;

namespace Common
{
    public static class TimeStopper
    {
        public static bool IsTimeStopped { get; private set; }

        public static void StopTime()
        {
            Time.timeScale = 0;
            IsTimeStopped = true;
        }

        public static void ResumeTime()
        {
            Time.timeScale = 1;
            IsTimeStopped = false;
        }
    }
}