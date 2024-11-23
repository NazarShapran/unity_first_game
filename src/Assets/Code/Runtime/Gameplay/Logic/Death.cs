using System;
using Code.Runtime.infrastructure.Service.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Death : MonoBehaviour
    {
        [SerializeField] 
        private Health _health;

        private IInputService _inputService;
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _feorceOnDeath;

        [SerializeField]
        private Collider2D _collaider;


        private void OnValidate()
        {
            _health ??= GetComponent<Health>();
            _rigidbody ??= GetComponent<Rigidbody2D>();
            _collaider ??= GetComponent<Collider2D>();
        }

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Awake()
        {
            _health.Death += OnDeath;
        }

        private void OnDestroy()
        {
            _health.Death -= OnDeath;
        }

        private void OnDeath()
        {
            _inputService.Disable();
            _rigidbody.AddForce(Vector2.up * _feorceOnDeath, ForceMode2D.Impulse);
            _collaider.enabled = false;
        }
    }
}