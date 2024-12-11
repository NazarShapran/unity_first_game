using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;

namespace Code.Runtime.infrastructure.Service.Shop
{
    public interface IShopService : IReadProgress, IWriteProgress
    {
        bool CanBuyItem(HatTypeId hatType);
        void BuyItem(HatTypeId hatType);
        
    }
}