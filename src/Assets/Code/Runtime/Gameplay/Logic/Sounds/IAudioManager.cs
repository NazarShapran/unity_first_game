using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Code.Runtime.Data;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Sounds
{
    public interface IAudioManager
    {
        void Play(SoundType soundType);
        void Stop(SoundType soundType);
        void FadeIn(SoundType soundType, float targetVolume, float duration);
        void FadeOut(SoundType soundType, float duration);
    }
}