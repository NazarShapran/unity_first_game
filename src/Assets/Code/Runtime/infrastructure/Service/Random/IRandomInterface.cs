using System.Collections.Generic;
using UnityEngine;

namespace Code.Runtime.infrastructure.Service.Random
{
    public interface IRandomInterface
    {
        float Range(float minInclusive, float maxInclusive);
        T ChooseFromList<T>(List<T> List);
    }
}