using Codebase.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.ECS.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private EcsFilter<MoveComponent, TransformComponent> _moveFilter = default;
        
        public void Run()
        {
            foreach (var entityId in _moveFilter)
            {
                ref MoveComponent moveComponent = ref _moveFilter.Get1(entityId);
                ref TransformComponent transformComponent = ref _moveFilter.Get2(entityId);

                transformComponent.Transform.position += moveComponent.Direction * (moveComponent.Speed * Time.deltaTime);
            }
        }
    }
}