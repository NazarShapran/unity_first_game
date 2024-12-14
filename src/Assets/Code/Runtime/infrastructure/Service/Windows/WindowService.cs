using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.StaticData;
using Code.Runtime.infrastructure.Service.TimeService;
using UnityEngine;
using Zenject;

namespace Code.Runtime.infrastructure.Service.Windows
{
    public class WindowService : IWindowService
    {
        private IStaticDataService _staticDataService;
        private IInstantiator _instantiator;
        private ITimeService _timeService;
        
        private GameObject _openedWindowPrefab = null;
        private Vector3 WindowInitialPos = new Vector3(0, 0, 0);
        
        [Inject]
        private void Construct(IInstantiator instantiator, IStaticDataService staticDataService, ITimeService timeService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
            _timeService = timeService;
        }

        public void OpenWindow(WindowTypeId windowTypeId)
        {
            _timeService.Stop();
            GameObject toSpawn = _staticDataService.GetWindowConfig(windowTypeId).WindowPrefab;
            if (toSpawn == null)
            {
                Debug.LogWarning("No prefab found for " + windowTypeId);
                return;
            }

            _openedWindowPrefab = _instantiator.InstantiatePrefab(toSpawn, WindowInitialPos, Quaternion.identity, null);
        }
        public void CloseWindow()
        {
            _timeService.Resume();
            if(_openedWindowPrefab != null)
                Object.Destroy(_openedWindowPrefab);
        }
    }
}