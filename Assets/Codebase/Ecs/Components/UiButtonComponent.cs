using System;
using Codebase.Views;

namespace Codebase.Ecs.Components
{
    [Serializable]
    public struct UiButtonComponent
    {
        public SpawnButtonView ButtonView;
    }
}