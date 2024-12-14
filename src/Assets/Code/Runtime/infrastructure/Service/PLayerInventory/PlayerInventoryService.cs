using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.PLayerInventory
{
    public class PlayerInventoryService : IPlayerInventoryService
    {
        private List<HatTypeId> _hats = new();
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
        public void Read(PlayerProgress playerProgress)
        {
            _hats = playerProgress.OwnedHats;
            SelectedHat = playerProgress.SelectedHat;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.OwnedHats = _hats;
            playerProgress.SelectedHat = SelectedHat;
        }
    }
}
