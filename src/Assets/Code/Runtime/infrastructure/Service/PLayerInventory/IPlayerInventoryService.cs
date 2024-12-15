using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;

namespace Code.Runtime.infrastructure.Service.PLayerInventory
{
    public interface IPlayerInventoryService :  IReadProgress, IWriteProgress
    {
        void AddHat(HatTypeId hatTypeId);
        bool HasAnyHat { get; }
        HatTypeId SelectedHat { get; }
        void SelectNextHat();
        void AddJump(JumpTypeId jumpTypeId);
        JumpTypeId GetMaxJump();
    }
}