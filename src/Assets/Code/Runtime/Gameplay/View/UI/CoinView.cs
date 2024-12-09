using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Services.Wallet;
using TMPro;
using UnityEngine;
using Zenject;


namespace Code.Runtime.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _coinText;

        private IWalletService _walletService;
        
        [Inject]
        private void Construct(IWalletService walletService)
        {
            _walletService = walletService;
        }

        private void Update()
        {
            _coinText.text = _walletService.Balance.ToString();
        }
    }
}