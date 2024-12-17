using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Jumps
{
    public class SetMaxJumpsCount
    {
        private readonly IStaticDataService _staticDataService;
        public int MaxJumpCount { get; private set; }

        
        public SetMaxJumpsCount(IStaticDataService staticDataService) 
            => _staticDataService = staticDataService;

        public void SetJumpTypeId(JumpTypeId jumpTypeId) 
            => MaxJumpCount = _staticDataService.GetJumpConfig(jumpTypeId).JumpsAmount;
    }
}