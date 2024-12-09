using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Services.Wallet;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Runtime.Gameplay.View.UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField]
        private CoinView _coinView;
        [SerializeField]
        private HealthBar _healthBar;
        
        public void Setup( Health health)
        {
            _healthBar.SetUp(health);
        }
    }
}