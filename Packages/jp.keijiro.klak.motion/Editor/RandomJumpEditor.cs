using UnityEngine;
using UnityEditor;

namespace Klak.Motion
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RandomJump))]
    sealed class RandomJumpEditor : Editor
    {
        SerializedProperty _minDistance;
        SerializedProperty _maxDistance;
        SerializedProperty _minAngle;
        SerializedProperty _maxAngle;

        static class Styles
        {
            public static readonly GUIContent min = new GUIContent("Min");
            public static readonly GUIContent max = new GUIContent("Max");
        }

        void OnEnable()
        {
            _minDistance = serializedObject.FindProperty("minDistance");
            _maxDistance = serializedObject.FindProperty("maxDistance");
            _minAngle = serializedObject.FindProperty("minAngle");
            _maxAngle = serializedObject.FindProperty("maxAngle");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var showSubLabels = EditorGUIUtility.currentViewWidth > 340;
            var originalLabelWidth = EditorGUIUtility.labelWidth;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Distance");

            if (showSubLabels)
            {
                EditorGUIUtility.labelWidth = 23;
                EditorGUILayout.PropertyField(_minDistance, Styles.min);
                EditorGUIUtility.labelWidth = 27;
                EditorGUILayout.PropertyField(_maxDistance, Styles.max);
                EditorGUIUtility.labelWidth = originalLabelWidth;
            }
            else
            {
                EditorGUILayout.PropertyField(_minDistance, GUIContent.none);
                EditorGUILayout.PropertyField(_maxDistance, GUIContent.none);
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Angle");

            if (showSubLabels)
            {
                EditorGUIUtility.labelWidth = 23;
                EditorGUILayout.PropertyField(_minAngle, Styles.min);
                EditorGUIUtility.labelWidth = 27;
                EditorGUILayout.PropertyField(_maxAngle, Styles.max);
                EditorGUIUtility.labelWidth = originalLabelWidth;
            }
            else
            {
                EditorGUILayout.PropertyField(_minAngle, GUIContent.none);
                EditorGUILayout.PropertyField(_maxAngle, GUIContent.none);
            }

            EditorGUILayout.EndHorizontal();

            if (EditorApplication.isPlaying && GUILayout.Button("Jump"))
                foreach (RandomJump rj in targets) rj.Jump();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
