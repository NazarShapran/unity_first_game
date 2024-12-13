using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Runtime.Gameplay.View
{
    public class MoveFadeDestroyer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRendrer;
        [SerializeField] private float _duration = 1;
        [SerializeField] private float _moveDeltaY = -1;

        public void Destroy()
        {
            DOTween.Sequence()
                .Join(Fade())
                .Join(Move())
                .OnComplete(() => Destroy(gameObject))
                .Play();
        }

        private Tween Move()
        {
            return gameObject
                .transform
                .DOMoveY(transform.position.y - _moveDeltaY, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);
        }

        private Tween Fade()
        {
            return _spriteRendrer
                .DOFade(0, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);
        }
    }
}