using System;

namespace Codebase.Ecs.Components
{
    [Serializable]
    public struct ClampXPositionComponent
    {
        public float MinBorder;
        public float MaxBorder;
    }
}