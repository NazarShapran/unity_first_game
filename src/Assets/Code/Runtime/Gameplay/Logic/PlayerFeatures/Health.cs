using System;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.PlayerFeatures
{
    public class Health : MonoBehaviour
    {
        public float MaxHealth { get; private set; }

        public float CurrentHealth;

        public event Action Changed;
        public event Action Death; 

        private void Start()
        {
            MaxHealth = CurrentHealth;
        }

        public void Subtract(float healthToSubtract)
        {
            if (healthToSubtract < 0)
            {
                throw new InvalidOperationException($"Heath to subtract cannot be negative: {healthToSubtract}");
            }
            CurrentHealth -= healthToSubtract;

            Changed?.Invoke();

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Death?.Invoke();
            }
        }

        public void Heal(float healthToHeal)
        {
            if (healthToHeal < 0)
                throw new InvalidOperationException($"Health to heal have to be positive but was {healthToHeal}");
            if (CurrentHealth <= 0)
            {
                return;
            }
            CurrentHealth += healthToHeal;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            Changed?.Invoke();
        }
    }
}