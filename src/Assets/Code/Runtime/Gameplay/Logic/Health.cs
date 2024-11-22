using System;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _currentHealth;

        public float MaxHealth { get; private set; }

        public float CurrentHealth => _currentHealth;

        private void Start()
        {
            MaxHealth = _currentHealth;
        }

        public void Subtract(float healthToSubtract)
        {
            if (healthToSubtract < 0)
            {
                throw new InvalidOperationException($"Heath to subtract cannot be negative: {healthToSubtract}");
            }
            _currentHealth -= healthToSubtract;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
            }
        }
    }
}