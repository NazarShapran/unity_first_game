using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Logic.Movements;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(Platform))]
    public class PlatformEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Selected)]
        private static void RenderCustomGizmo(Platform platform, GizmoType gizmo)
        {
            if (platform == null)
            {
                return;
            }
            if (platform.PointA == null || 
                platform.PointB == null || 
                platform.PointC == null)
                return;

            Handles.color = Color.red;

            Handles.DrawLine(platform.PointA.position, platform.PointB.position);
            Handles.DrawLine(platform.PointB.position, platform.PointC.position);
            Handles.DrawLine(platform.PointC.position, platform.PointA.position);

            Handles.SphereHandleCap(0, platform.PointA.position, Quaternion.identity, 0.2f, EventType.Repaint);
            Handles.SphereHandleCap(0, platform.PointB.position, Quaternion.identity, 0.2f, EventType.Repaint);
            Handles.SphereHandleCap(0, platform.PointC.position, Quaternion.identity, 0.2f, EventType.Repaint);

            Handles.Label(platform.PointA.position, "Point A", EditorStyles.boldLabel);
            Handles.Label(platform.PointB.position, "Point B", EditorStyles.boldLabel);
            Handles.Label(platform.PointC.position, "Point C", EditorStyles.boldLabel);
        }
    }
}