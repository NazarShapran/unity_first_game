using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.SaveLoad;
using Code.Runtime.infrastructure.SaveLoadRegistry;
using Code.Runtime.infrastructure.Service.Progress;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IProgressService _progressService;
        private readonly ISaveLoadRegistryService _saveLoadRegistry;
        private const string PlayerProgress = "LevelProgress";

        public SaveLoadService(IProgressService progressService, ISaveLoadRegistryService saveLoadRegistry)
        {
            _progressService = progressService;
            _saveLoadRegistry = saveLoadRegistry;
        }
        
        public void SaveProgress()
        {
            foreach (IWriteProgress writeProgress in _saveLoadRegistry.ProgressWriters)
            {
                writeProgress.Write(_progressService.PlayerProgress);
            }
            string json = JsonUtility.ToJson(_progressService.PlayerProgress);
            PlayerPrefs.SetString(PlayerProgress, json);
        }
        public PlayerProgress LoadProgress()
        {
            string json = PlayerPrefs.GetString(PlayerProgress);
            return JsonUtility.FromJson<PlayerProgress>(json);
        }
    }
}