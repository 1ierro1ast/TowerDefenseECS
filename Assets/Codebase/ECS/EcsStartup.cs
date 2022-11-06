using Codebase.ECS.Systems;
using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;

namespace Codebase.ECS
{
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
            
            _systems.Init();
        }

        private void AddSystems()
        {
            _systems
                .Add(new MoveSystem());
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
