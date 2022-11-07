using Codebase.Ecs.Components.OneFrames;
using Codebase.Ecs.Services;
using Codebase.Ecs.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Codebase.Ecs
{
    [RequireComponent(typeof(UnitsFactory))]
    [RequireComponent(typeof(GameVariables))]
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddSystems();
            AddOneFrames();
            AddInjections();
            
            _systems.Init();
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<SpawnButtonClicked>()
                .OneFrame<TimerEnd>();
        }

        private void AddSystems()
        {
            _systems
                .Add(new TimerSystem())
                .Add(new SpawnButtonClickHandlerSystem())
                .Add(new PlayerUnitViewCreateSystem())
                .Add(new MoveSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(GetComponent<IGameVariables>())
                .Inject(GetComponent<IUnitsFactory>());
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}
