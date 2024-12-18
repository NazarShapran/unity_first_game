using System;
using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;
using DG.Tweening;

namespace Code.Runtime.Gameplay.Logic.Sounds
{
    public class AudioManager : IAudioManager
    {
        private readonly IStaticDataService _staticDataService;
        private readonly GameObject _audioRoot;
        private readonly Dictionary<SoundType, AudioSource> _audioSources = new();

        public AudioManager(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _audioRoot = new GameObject("AudioManager");
            UnityEngine.Object.DontDestroyOnLoad(_audioRoot);
        }

        public void Play(SoundType soundType)
        {
            if (!TryGetAudioSource(soundType, out var audioSource))
            {
                var soundConfig = _staticDataService.GetSoundConfig(soundType);
                if (soundConfig == null || soundConfig.Sounds == null)
                {
                    Debug.LogWarning($"SoundConfig not found for soundType: {soundType}");
                    return;
                }

                audioSource = CreateAndAddAudioSource(soundType, soundConfig.Sounds);
            }

            audioSource.Play();
        }

        public void Stop(SoundType soundType)
        {
            if (TryGetAudioSource(soundType, out var audioSource) && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        public void FadeIn(SoundType soundType, float targetVolume, float duration)
        {
            if (!TryGetAudioSource(soundType, out var audioSource))
            {
                var soundConfig = _staticDataService.GetSoundConfig(soundType);
                if (soundConfig == null || soundConfig.Sounds == null)
                {
                    Debug.LogWarning($"SoundConfig not found for soundType: {soundType}");
                    return;
                }

                audioSource = CreateAndAddAudioSource(soundType, soundConfig.Sounds);
            }

            if (!audioSource.isPlaying)
            {
                audioSource.volume = 0f;
                audioSource.Play();
            }
            
            audioSource.DOFade(targetVolume, duration).SetEase(Ease.Linear);
        }

        public void FadeOut(SoundType soundType, float duration)
        {
            if (TryGetAudioSource(soundType, out var audioSource) && audioSource.isPlaying)
            {
                audioSource.DOFade(0f, duration).SetEase(Ease.Linear).OnComplete(audioSource.Stop);
            }
        }

        private bool TryGetAudioSource(SoundType soundType, out AudioSource audioSource)
        {
            return _audioSources.TryGetValue(soundType, out audioSource);
        }

        private AudioSource CreateAndAddAudioSource(SoundType soundType, Sound sound)
        {
            var audioSource = _audioRoot.AddComponent<AudioSource>();
            audioSource.clip = sound.clip;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;
            audioSource.loop = sound.loop;
            audioSource.outputAudioMixerGroup = sound.mixer;

            _audioSources[soundType] = audioSource;
            return audioSource;
        }
    }
}
