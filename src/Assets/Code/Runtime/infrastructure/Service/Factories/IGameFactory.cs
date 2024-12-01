using UnityEngine;

namespace Code.Runtime.infrastructure.Service.Factories
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Vector3 position);
        GameObject CreateHud(GameObject player);
    }
}