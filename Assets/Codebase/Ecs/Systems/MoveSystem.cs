using Codebase.Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Ecs.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = default;
        private readonly EcsFilter<MoveComponent, TransformComponent> _moveFilter = default;
        
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