using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
using System;
using Code.Runtime.Data;

namespace Code.Runtime.Gameplay.Logic.Sounds
{
    public class AudioManager : MonoBehaviour
    {
        public AudioManager instance;

        public Sound[] sounds;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.mixer;
            }
        }

        public void Play(SoundType soundType)
        {
            string soundName = soundType.ToString();
            Sound s = Array.Find(sounds, item => item.name == soundName);
            if (s == null)
            {
                Debug.LogWarning($"Sound '{soundName}' not found!");
                return;
            }
            s.source.Play();
        }

        public void Stop(SoundType soundType)
        {
            string soundName = soundType.ToString();
            Sound s = Array.Find(sounds, item => item.name == soundName);
            if (s == null)
            {
                Debug.LogWarning($"Sound '{soundName}' not found!");
                return;
            }
            s.source.Stop();
        }

        public void FadeIn(SoundType soundType, float targetVolume, float duration)
        {
            string soundName = soundType.ToString();
            Sound s = Array.Find(sounds, item => item.name == soundName);
            if (s == null)
            {
                Debug.LogWarning($"Sound '{soundName}' not found!");
                return;
            }

            s.source.volume = 0f;
            s.source.Play();
            s.source.DOFade(targetVolume, duration).SetEase(Ease.Linear);
        }

        public void FadeOut(SoundType soundType, float duration)
        {
            string soundName = soundType.ToString();
            Sound s = Array.Find(sounds, item => item.name == soundName);
            if (s == null)
            {
                Debug.LogWarning($"Sound '{soundName}' not found!");
                return;
            }

            s.source.DOFade(0f, duration).SetEase(Ease.Linear).OnComplete(() =>
            {
                s.source.Stop();
            });
        }
    }
}
