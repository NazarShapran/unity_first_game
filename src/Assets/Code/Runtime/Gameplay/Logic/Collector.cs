using Unity.VisualScripting;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Collector : MonoBehaviour
    {
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out ICollectable collectable)) 
                return;
            
            if (collectable.IsCollected) 
                return;
            
            collectable.Collect(this);
        }
    }
}