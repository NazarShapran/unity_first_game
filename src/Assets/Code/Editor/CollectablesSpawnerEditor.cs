using Code.Runtime.Extensions;
using Code.Runtime.Gameplay.Logic;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(CollectablesSpawner))]
    public class CollectablesSpawnerEditor : UnityEditor.Editor
    {
        private const float RandomXRangeThickness = 3;
        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CollectablesSpawner spawner, GizmoType gizmo)
        {
            Vector3 transformPosition = spawner.transform.position;
            Handles.DrawLine(transformPosition.SetX(-spawner.RandomDetailX), transformPosition.SetX(spawner.RandomDetailX), RandomXRangeThickness);
        }

    }
}