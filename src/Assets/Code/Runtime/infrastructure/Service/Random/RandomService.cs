using System.Collections.Generic;

namespace Code.Runtime.infrastructure.Service.Random
{
    public class RandomService : IRandomInterface 
    {
        public int Range(int minInclusive, int maxInclusive) => 
            UnityEngine.Random.Range(minInclusive, maxInclusive);

        public T ChooseFromList<T>(List<T> List)
        {
            if (List.Count == 0)
            {
                return default;
            }
            
            int index = UnityEngine.Random.Range(0, List.Count);
            return List[index];
        }
    }
}