using Code.Runtime.infrastructure.SaveLoad;

namespace Code.Runtime.Gameplay.Services.Wallet
{
    public interface IWalletService : IWriteProgress, IReadProgress
    {
        int Balance { get; }
        void AddCoin();
        bool IsEnoughMoney(int hatConfigPrice);
        void Purchase(int price);
        void minusCoins(int coinsToMinus);
    }
}