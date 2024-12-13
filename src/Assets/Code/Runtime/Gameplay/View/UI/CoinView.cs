using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Services.Wallet;
using TMPro;
using UnityEngine;
using Zenject;


namespace Code.Runtime.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] PunchAnimation _punchAnimation;

        private IWalletService _walletService;

        private int _lastValue;

        [Inject]
        private void Construct(IWalletService walletService)
        {
            _walletService = walletService;
        }

        private void Update()
        {
            int newValue = _walletService.Balance;
            if (_lastValue != newValue)
            {
                _punchAnimation.Animate();
            }

            _coinText.text = _walletService.Balance.ToString();
            _lastValue = _walletService.Balance;
        }
    }
}