using Codebase.Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Ecs.Systems
{
    public class ClampPositionSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = default;
        private readonly EcsFilter<ClampXPositionComponent, TransformComponent> _clampedFilter = default;

        public void Run()
        {
            foreach (var entityId in _clampedFilter)
            {
                ref ClampXPositionComponent clampXPositionComponent = ref _clampedFilter.Get1(entityId);
                ref TransformComponent transformComponent = ref _clampedFilter.Get2(entityId);

                var position = transformComponent.Transform.position;

                transformComponent.Transform.position = new Vector3(
                    Mathf.Clamp(position.x, clampXPositionComponent.MinBorder, clampXPositionComponent.MaxBorder),
                    position.y,
                    position.z);
            }
        }
    }
}