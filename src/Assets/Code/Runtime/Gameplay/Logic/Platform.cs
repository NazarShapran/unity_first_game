using System;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] public Transform PointA;
        [SerializeField] public Transform PointB;
        [SerializeField] public Transform PointC;
        [SerializeField] private float _speed = 2f;

        private Transform[] _points;
        private int _currentPointIndex;
        private Vector3 _target;

        private void Start()
        {
            _points = new Transform[] { PointA, PointB, PointC };
            _currentPointIndex = 0;

            transform.position = _points[_currentPointIndex].position;
            UpdateTarget();
        }

        private void Update()
        {
            Vector3 previousPosition = transform.position;
            
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
            
            if (HasPassedTarget(previousPosition, _target))
            {
                UpdateTarget();
            }
        }

        private void UpdateTarget()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
            _target = _points[_currentPointIndex].position;
        }

        private bool HasPassedTarget(Vector3 currentPosition, Vector3 target)
        {
            Vector3 toTarget = target - currentPosition;
            Vector3 toNext = target - transform.position;

            return Vector3.Dot(toTarget.normalized, toNext.normalized) <= 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<MovingPlatformAttachable>() == null)
                return;

            other.transform.SetParent(transform);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<MovingPlatformAttachable>() == null)
                return;

            other.transform.SetParent(null);
        }
    }
}
