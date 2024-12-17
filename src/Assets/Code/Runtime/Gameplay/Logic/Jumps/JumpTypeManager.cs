using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Jumps
{
    public class JumpTypeManager
    {
        private IStaticDataService _staticDataService;
        public int MaxJumpCount { get; private set; }

        
        public JumpTypeManager(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void SetJumpTypeId(JumpTypeId jumpTypeId)
        {
            MaxJumpCount = _staticDataService.GetJumpConfig(jumpTypeId).JumpsAmount;
            Debug.Log($"Jump Type Changed to {jumpTypeId}, Max Jumps: {MaxJumpCount}");
        }
    }
}