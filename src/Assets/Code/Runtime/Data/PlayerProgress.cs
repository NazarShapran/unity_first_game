using System;
using System.Collections.Generic;
using Code.Runtime.Gameplay.View.UI.Shop;
using UnityEngine.Serialization;

namespace Code.Runtime.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Coins;
        public List<ShopItemId> PurchesedItems = new();
        public List<HatTypeId> OwnedHats = new();
        public List<JumpTypeId> OwnedJumps = new();
        public HatTypeId SelectedHat = HatTypeId.None;
    }
}