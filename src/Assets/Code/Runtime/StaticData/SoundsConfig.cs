using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "SoundsConfig", menuName = "StaticData/SoundsConfig")]
    public class SoundsConfig : ScriptableObject
    {
        public SoundType Sound;
        public Sound Sounds;
    }
}