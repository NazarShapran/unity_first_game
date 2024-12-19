using System.Collections.Generic;

namespace Code.Runtime.infrastructure.Service.Random
{
    public class RandomService : IRandomInterface
    {
        public int Range(int minInclusive, int maxInclusive) =>
            UnityEngine.Random.Range(minInclusive, maxInclusive);

        public T ChooseFromList<T>(List<T> list)
        {
            if (list.Count == 0)
                return default;

            int index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }

        public T ChooseWeighted<T>(List<(T Item, int Weight)> items)
        {
            if (items == null || items.Count == 0)
                return default;

            int totalWeight = 0;
            foreach (var (_, weight) in items)
                totalWeight += weight;

            int randomPoint = UnityEngine.Random.Range(0, totalWeight);
            foreach (var (item, weight) in items)
            {   
                if (randomPoint < weight)
                    return item;
                randomPoint -= weight;
            }

            return default;
        }
    }
}