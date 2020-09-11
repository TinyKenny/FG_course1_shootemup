using UnityEditor;
using UnityEngine;

namespace ShootEmUp
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : Editor
    {
        private Tool lastTool = Tool.None;
        private void OnEnable()
        {
            lastTool = Tools.current;
            Tools.current = Tool.None;
        }

        private void OnDisable()
        {
            Tools.current = lastTool;
        }

        private void OnSceneGUI()
        {
            SerializedProperty spawnPointsProperty = serializedObject.FindProperty("spawnPoints");
            int arraySize = spawnPointsProperty.arraySize;

            for (int i = 0; i < arraySize; i++)
            {
                SerializedProperty elementProperty = spawnPointsProperty.GetArrayElementAtIndex(i);
                Vector3 spawnPoint = elementProperty.vector3Value;
                
                EditorGUI.BeginChangeCheck();
                spawnPoint = Handles.PositionHandle(spawnPoint, Quaternion.identity);
                if (EditorGUI.EndChangeCheck())
                {
                    spawnPoint.z = 0.0f;
                    elementProperty.vector3Value = spawnPoint;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
