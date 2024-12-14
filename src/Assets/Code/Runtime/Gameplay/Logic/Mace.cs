using Code.Runtime.Gameplay.Logic.Sounds;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Mace : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private float _healthToSubstract;

        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            IsCollected = true;
            AudioManager.instance.Play("Mace");
            collector.GetComponent<Health>().Subtract(_healthToSubstract);
        }
    }
}