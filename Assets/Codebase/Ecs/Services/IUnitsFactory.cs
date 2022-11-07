using Codebase.Views;

namespace Codebase.Ecs.Services
{
    public interface IUnitsFactory
    {
        IUnit CreateUnit(float x, float y);
    }
}
