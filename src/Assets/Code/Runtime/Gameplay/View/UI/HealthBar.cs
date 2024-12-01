using System;
using Code.Runtime.Gameplay.Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class HealthBar : MonoBehaviour
    {

        [SerializeField]
        private Image _image;

        private Health _health;
        
        public void SetUp(Health health)
        {
            _health = health;
            _health.Changed += OnHealthChanged;
        }
        private void OnDestroy()
        {
            _health.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _image.fillAmount = _health.CurrentHealth / _health.MaxHealth;
        }
    }
}