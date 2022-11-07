using Codebase.Views;
using UnityEngine;

namespace Codebase.Ecs.Services
{
    public class UnitsFactory : MonoBehaviour, IUnitsFactory
    {
        [SerializeField] private Unit _prefab;

        public IUnit CreateUnit(float x, float y)
        {
            var position = new Vector2(x, y);
            var rotation = Quaternion.identity;

            var unit = Instantiate(_prefab, position, rotation);

            return unit;
        }
    }
}