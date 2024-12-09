using Code.Runtime.Gameplay.Markers;
using Code.Runtime.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Editor
{
    [CustomEditor(typeof(LevelData))]
    public class LevelStateDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            base.OnInspectorGUI();
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("Collect data"))
            {
                CollectData();
            }
        }

        private void CollectData()
        {
            LevelData levelData = (LevelData)target;
            levelData.LevelName = SceneManager.GetActiveScene().name;
            levelData.PlayerSpawnPoint = FindObjectOfType<PlayerSpawnPoint>().transform.position;
        }
    }
}