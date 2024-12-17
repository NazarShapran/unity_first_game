using System;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;
using UnityEngine;

namespace Code.Runtime.Gameplay.Services.Wallet
{
    public class WalletService : IWalletService
    {
        [SerializeField] private int _balance;

        public int Balance => _balance;

        public void AddCoin() => _balance++;

        public bool IsEnoughMoney(int hatConfigPrice)
        {
            return _balance >= hatConfigPrice;
        }

        public void Purchase(int price)
        {
            if (!IsEnoughMoney(price))
                throw new InvalidOperationException("Not enough money");
            _balance -= price;
        }

        public void MinusCoins(int coinsToMinus)
        {
            if (coinsToMinus < 0)
                throw new InvalidOperationException($"Coins to steal have to be positive but was {coinsToMinus}");
            if (_balance < 0)
                return;
            _balance -= coinsToMinus;
            if (_balance < 0)
                _balance = 0;
        }

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