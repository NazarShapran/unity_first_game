using Code.Runtime.Gameplay.Logic;
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
        
        public void Setup(Wallet wallet, Health health)
        {
            _coinView.SetUp(wallet);    
            _healthBar.SetUp(health);
        }
    }
}