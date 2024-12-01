using Code.Runtime.StaticData;

namespace Code.Runtime.infrastructure.Service.StaticData
{
    public interface IStaticDataService
    {
        HudConfig HUDConfig { get; }
        PlayerConfig PlayerConfig { get; }
        void LoadAll();
    }
}