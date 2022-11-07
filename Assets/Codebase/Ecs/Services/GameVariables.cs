using UnityEngine;

namespace Codebase.Ecs.Services
{
    public class GameVariables : MonoBehaviour, IGameVariables
    {
        [SerializeField] private int _coins;
        public int Coins => _coins;
    }
}