using System;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    [Serializable]
    public class CollectableConfig
    {
        public GameObject CollectablePrefab;
        [Range(1, 100)] 
        public int Weight = 1;
    }
}