using Codebase.Ecs.Components;
using Codebase.Ecs.Components.OneFrames;
using Leopotam.Ecs;

namespace Codebase.Ecs.Systems
{
    public class SpawnButtonClickHandlerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly EcsFilter<UiButtonComponent, SpawnTagComponent> _spawnButtonsFilter = default;

        public void Run()
        {
            foreach (var entityId in _spawnButtonsFilter)
            {
                ref UiButtonComponent uiButtonComponent = ref _spawnButtonsFilter.Get1(entityId);
                if (uiButtonComponent.ButtonView.ButtonClicked)
                {
                    _spawnButtonsFilter.GetEntity(entityId).Get<SpawnButtonClicked>();
                }
            }
        }
    }
}