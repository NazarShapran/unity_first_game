using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Collector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.TryGetComponent(out ICollectable collectable)) 
                 collectable.Collect(this);
        }
    }
}