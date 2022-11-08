using Codebase.Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Ecs.Systems
{
    public class CameraHandleDirectionSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = default;
        private readonly EcsFilter<MoveComponent, CameraTagComponent> _cameraFilter = default;

        public void Run()
        {
            foreach (var entityId in _cameraFilter)
            {
                ref MoveComponent moveComponent = ref _cameraFilter.Get1(entityId);

                var mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                var directionCoefficient = 0;

                if (mousePosition.x is < 1 and > 0.9f) directionCoefficient = 1;
                if (mousePosition.x is < 0.1f and > 0f) directionCoefficient = -1;

                moveComponent.Direction = new Vector3(directionCoefficient, moveComponent.Direction.y,
                    moveComponent.Direction.z);
            }
        }
    }
}