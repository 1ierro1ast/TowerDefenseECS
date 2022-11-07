using System;

namespace Codebase.Ecs.Components
{
    [Serializable]
    public struct TimerComponent
    {
        public float Time;
        public float CurrentTime;
        public bool LoopTimer;
    }
}