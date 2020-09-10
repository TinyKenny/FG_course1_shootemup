using System;
using UnityEditor;
using UnityEngine;

namespace ShootEmUp
{
    [CustomEditor(typeof(SemiAutoShotgun))]
    public class SemiAutoShotgunEditor : Editor
    {
        private const float minimumAttacksPerSecond = 0.01f;
        private const float maximumAttacksPerSecond = 100.0f;
        private SerializedProperty timeBetweenShotsProperty = null;
        
        private void OnEnable()
        {
            timeBetweenShotsProperty = serializedObject.FindProperty("secondsBetweenShots");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.BeginVertical();

            timeBetweenShotsProperty.floatValue = 1.0f /
                                                  Mathf.Clamp(
                                                      EditorGUILayout.FloatField("Attacks per second",
                                                          1.0f / timeBetweenShotsProperty.floatValue),
                                                      minimumAttacksPerSecond, maximumAttacksPerSecond);
            
            serializedObject.ApplyModifiedProperties();
            
            GUILayout.EndVertical();
        }
    }
}
