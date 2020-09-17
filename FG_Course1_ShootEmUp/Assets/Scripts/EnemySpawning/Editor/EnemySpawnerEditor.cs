using Unity.Mathematics;
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
            SerializedProperty spawnMinPointProperty = serializedObject.FindProperty("spawnMinPoint");
            SerializedProperty spawnMaxPointProperty = serializedObject.FindProperty("spawnMaxPoint");
            
            Vector2 spawnMinPoint = spawnMinPointProperty.vector2Value;
            EditorGUI.BeginChangeCheck();
            spawnMinPoint = Handles.PositionHandle(spawnMinPoint, quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                spawnMinPointProperty.vector2Value = spawnMinPoint;
            }
            
            Vector2 spawnMaxPoint = spawnMaxPointProperty.vector2Value;
            EditorGUI.BeginChangeCheck();
            spawnMaxPoint = Handles.PositionHandle(spawnMaxPoint, quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                spawnMaxPointProperty.vector2Value = spawnMaxPoint;
            }
            serializedObject.ApplyModifiedProperties();

            

        }
    }
}
