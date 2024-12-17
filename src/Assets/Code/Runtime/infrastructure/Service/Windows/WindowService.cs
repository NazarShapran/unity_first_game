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
        private GameObject _currentWindow;
        private Vector3 DefaultWindowPosition = Vector3.zero;

        [Inject]
        private void Construct(IInstantiator instantiator, IStaticDataService staticDataService,
            ITimeService timeService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
            _timeService = timeService;
        }

        public void OpenWindow(WindowTypeId windowTypeId)
        {
            CloseWindow();

            _timeService.Stop();

            var config = _staticDataService.GetWindowConfig(windowTypeId);
            if (config?.WindowPrefab == null)
            {
                Debug.LogWarning($"WindowConfig for '{windowTypeId}' not found or prefab is null.");
                return;
            }

            _currentWindow = _instantiator
                .InstantiatePrefab(
                    config.WindowPrefab,
                    DefaultWindowPosition,
                    Quaternion.identity,
                    null);
        }

        public void CloseWindow()
        {
            if (_currentWindow != null)
            {
                Object.Destroy(_currentWindow);
                _currentWindow = null;
            }

            _timeService.Resume();
        }
    }
}