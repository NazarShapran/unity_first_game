using System.Collections.Generic;
using System.Linq;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.PLayerInventory
{
    public class PlayerInventoryService : IPlayerInventoryService
    {
        private List<HatTypeId> _hats = new();
        private List<JumpTypeId> _jumps = new();
        public HatTypeId SelectedHat { get; private set; }

        public bool HasAnyHat => _hats.Count > 0;

        public void AddHat(HatTypeId hatTypeId)
        {
            _hats.Add(hatTypeId);
        }

        public void SelectNextHat()
        {
            int findIndex = _hats.FindIndex(x => x == SelectedHat);

            if (findIndex < _hats.Count - 1)
            {
                SelectedHat = _hats[findIndex + 1];
            }
            else
            {
                SelectedHat = HatTypeId.None;
            }
        }

        public void AddJump(JumpTypeId jumpTypeId)
        {
            _jumps.Add(jumpTypeId);
        }

        public JumpTypeId GetMaxJump()
        {
            if (_jumps.Count > 0)
            {
                return _jumps.Max();
            }
            return JumpTypeId.None;
        }

        public void Read(PlayerProgress playerProgress)
        {
            _hats = playerProgress.OwnedHats;
            SelectedHat = playerProgress.SelectedHat;
            _jumps = playerProgress.OwnedJumps;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.OwnedHats = _hats;
            playerProgress.SelectedHat = SelectedHat;
            playerProgress.OwnedJumps = _jumps;
        }
    }
}
