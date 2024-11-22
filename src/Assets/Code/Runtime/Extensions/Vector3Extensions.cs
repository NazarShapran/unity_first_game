using UnityEngine;

namespace Code.Runtime.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 vector, float x) => 
            new (x, vector.y, vector.z);
        
        public static Vector3 AddX(this Vector3 vector, float x) => 
            vector.SetX(vector.x + x);
         
    }
}