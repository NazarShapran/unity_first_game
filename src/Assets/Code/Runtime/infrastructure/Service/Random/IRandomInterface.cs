using System.Collections.Generic;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.Random
{
    public interface IRandomInterface
    {
        int Range(int minInclusive, int maxInclusive);
        T ChooseFromList<T>(List<T> List);
    }
}