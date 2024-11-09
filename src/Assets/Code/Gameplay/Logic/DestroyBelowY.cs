using UnityEngine;

namespace Code.Gameplay.Logic
{
    public class DestroyBelowY : MonoBehaviour
    {
        [SerializeField]
        private float _y;

        private void Update()
        {
            if (transform.position.y < _y)
            {
               Destroy(gameObject);
            }
        }
    }
}