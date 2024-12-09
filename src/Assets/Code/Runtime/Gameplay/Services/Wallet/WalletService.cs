using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;
using UnityEngine;

namespace Code.Runtime.Gameplay.Services.Wallet
{
    public class WalletService : IWalletService
    {
        [SerializeField]
        private int _balance;

        public int Balance => _balance;

        public void AddCoin() => _balance++;

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.Coins = _balance;
        }

        public void Read(PlayerProgress playerProgress)
        {
            _balance = playerProgress.Coins;
        }
    }
}