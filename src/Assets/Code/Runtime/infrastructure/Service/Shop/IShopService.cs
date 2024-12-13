using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.infrastructure.SaveLoad;

namespace Code.Runtime.infrastructure.Service.Shop
{
    public interface IShopService : IReadProgress, IWriteProgress
    {
        bool CanBuyItem(ShopItemId hatType);
        void BuyItem(ShopItemId hatType);
        
    }
}