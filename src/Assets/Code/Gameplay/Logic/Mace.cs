using UnityEngine;

namespace Code.Gameplay.Logic
{
    public class Mace : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private float _healthToSubstract;

        public void Collect(Collector collector)
        {
            collector.GetComponent<Health>().Subtract(_healthToSubstract);
        }
    }
}