using Game.Scripts.Root.Services;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private LoadSprites _loadSprites;
        
        private void Awake()
        {
            ServiceLocator.Instance.RegisterSingle(_loadSprites);
        }
    }
}