using Codebase.Ecs.Components;
using Codebase.Ecs.Components.OneFrames;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Ecs.Systems
{
    public class TimerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly EcsFilter<TimerComponent> _ecsFilter = default;

        public void Init()
        {
            foreach (var entityId in _ecsFilter)
            {
                ref TimerComponent timerComponent = ref _ecsFilter.Get1(entityId);
                ResetTime(ref timerComponent);
            }
        }

        public void Run()
        {
            foreach (var entityId in _ecsFilter)
            {
                ref TimerComponent timerComponent = ref _ecsFilter.Get1(entityId);
                timerComponent.CurrentTime -= Time.deltaTime;
                if (timerComponent.CurrentTime <= 0)
                {
                    ref EcsEntity entity = ref _ecsFilter.GetEntity(entityId);
                    entity.Get<TimerEnd>();
                    if (timerComponent.LoopTimer) ResetTime(ref timerComponent);
                }
            }
        }

        private void ResetTime(ref TimerComponent timerComponent)
        {
            timerComponent.CurrentTime = timerComponent.Time;
        }
    }
}