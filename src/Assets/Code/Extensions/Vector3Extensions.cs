using UnityEngine;

namespace Code.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 vector, float x) => 
            new (x, vector.y, vector.z);
         
    }
}