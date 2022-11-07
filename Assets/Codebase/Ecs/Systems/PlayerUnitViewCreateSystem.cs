using Codebase.Ecs.Components;
using Codebase.Ecs.Components.OneFrames;
using Codebase.Ecs.Services;
using Leopotam.Ecs;

namespace Codebase.Ecs.Systems
{
    public class PlayerUnitViewCreateSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly IUnitsFactory _unitsFactory = default;

        private EcsFilter<SpawnButtonClicked, SpawnTagComponent> _clickedSpawnButtonFilter = default;
        private EcsFilter<PointComponent, SpawnTagComponent> _spawnPointFilter = default;

        public void Run()
        {
            foreach (var entityId in _clickedSpawnButtonFilter)
            {
                ref PointComponent pointComponent = ref _spawnPointFilter.Get1(entityId);
                var position = pointComponent.Point;
                
                _unitsFactory.CreateUnit(
                    position.x,
                    position.y);
            }
        }
    }
}