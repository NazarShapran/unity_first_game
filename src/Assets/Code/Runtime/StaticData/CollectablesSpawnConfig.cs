using System.Collections.Generic;
using Code.Runtime.Gameplay.Logic.Collectables;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "CollectablesSpawnConfig", menuName = "Configs/Collectables Spawn Config")]
    public class CollectablesSpawnConfig : ScriptableObject
    {
        public List<CollectableConfig> Collectables;
    }
}