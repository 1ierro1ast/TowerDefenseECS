using System;
using UnityEngine;

namespace Codebase.Ecs.Components
{
    [Serializable]
    public struct MoveComponent
    {
        public float Speed;
        public Vector3 Direction;
    }
}