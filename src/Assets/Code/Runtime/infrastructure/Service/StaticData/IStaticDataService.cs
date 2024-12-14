using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.StaticData;

namespace Code.Runtime.infrastructure.Service.StaticData
{
    public interface IStaticDataService
    {
        HudConfig HUDConfig { get; }
        PlayerConfig PlayerConfig { get; }
        WindowConfig WindowConfig { get; }
        void LoadAll();
        LevelData GetLevelData(string levelName);
        ShopItemConfig GetShopItemConfig(ShopItemId hatTypeId);
        IEnumerable<ShopItemConfig> GetHatsConfigs();
        HatConfig GetHatConfig(HatTypeId hatTypeId);
        WindowConfig GetWindowConfig(WindowTypeId windowTypeId);
    }
}