using System.Collections.Generic;
using System.Linq;
using Code.Runtime.infrastructure.GameStates.States;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelData> _levelData;
        public HudConfig HUDConfig { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
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
    }
}