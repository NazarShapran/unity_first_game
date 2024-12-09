using Code.Runtime.Data;

namespace Code.Runtime.infrastructure.Service.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}