using DG.Tweening;
using UnityEngine;

namespace Code.Runtime.Gameplay.View.UI
{
    public class PunchAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;

        [SerializeField] private float _tagretScale = 1.1f;

        [SerializeField] private float _duration = 0.2f;
        private Tweener _currentTweener;

        public void Animate()
        {
            _currentTweener?.Kill(true);
            
            _currentTweener = _target
                .DOPunchScale(Vector3.one * _tagretScale, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);
        }
    }
}