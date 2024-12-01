using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public HudConfig HUDConfig { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
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