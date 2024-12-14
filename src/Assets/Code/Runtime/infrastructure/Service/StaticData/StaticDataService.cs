using System.Collections.Generic;
using System.Linq;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelData> _levelData;
        private Dictionary<ShopItemId, ShopItemConfig> _shopItems;
        private Dictionary<HatTypeId, HatConfig> _hats;
        private Dictionary<WindowTypeId, WindowConfig> _windows;
        public HudConfig HUDConfig { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }
        public WindowConfig WindowConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
            LoadShopItems();
            LoadHatConfigs();
            LoadWindows();
        }

        

        public HatConfig GetHatConfig(HatTypeId hatTypeId) =>
            _hats.GetValueOrDefault(hatTypeId);

        public WindowConfig GetWindowConfig(WindowTypeId windowTypeId) => 
            _windows.GetValueOrDefault(windowTypeId);

        public ShopItemConfig GetShopItemConfig(ShopItemId hatTypeId) =>
            _shopItems.GetValueOrDefault(hatTypeId);

        public IEnumerable<ShopItemConfig> GetHatsConfigs() =>
            _shopItems.Values;


        private void LoadShopItems()
        {
            _shopItems = Resources
                .LoadAll<ShopItemConfig>("Configs/ShopItems")
                .ToDictionary(x => x.ShopItemId);
        }

        private void LoadHatConfigs()
        {
            _hats = Resources
                .LoadAll<HatConfig>("Configs/Hats")
                .ToDictionary(x => x.HatTypeId);
        }

        public LevelData GetLevelData(string levelName) => _levelData[levelName];

        private void LoadLevels()
        {
            _levelData = Resources.LoadAll<LevelData>("Configs/Levels").ToDictionary(level => level.LevelName);
        }

        private void LoadHudConfig()
        {
            HUDConfig = Resources.Load<HudConfig>("Configs/HudConfig");
        }

        private void LoadPlayerConfig()
        {
            PlayerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");
        }
        private void LoadWindows()
        {
            _windows = Resources.LoadAll<WindowConfig>("Configs/Windows").ToDictionary(x => x.WindowTypeId);
        }
    }
}