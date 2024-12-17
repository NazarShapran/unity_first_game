using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.PlayerFeatures;
using Code.Runtime.Gameplay.Logic.Sounds;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class Mace : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private float _healthToSubstract;
        
        private AudioManager _audioManager;
        
        [Inject]
        private void Construct(AudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            IsCollected = true;
            _audioManager.Play(SoundType.Mace);
            collector.GetComponent<Health>().Subtract(_healthToSubstract);
        }
    }
}