namespace Code.Runtime.infrastructure.Service.Random
{
    public class RandomService : IRandomInterface 
    {
        public float Range(float minInclusive, float maxInclusive) => 
            UnityEngine.Random.Range(minInclusive, maxInclusive);
    }
}