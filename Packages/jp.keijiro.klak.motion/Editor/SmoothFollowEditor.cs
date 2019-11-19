using UnityEngine;
using UnityEditor;

namespace Klak.Motion
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SmoothFollow))]
    sealed class SmoothFollowEditor : Editor
    {
        SerializedProperty _target;
        SerializedProperty _interpolator;
        SerializedProperty _positionSpeed;
        SerializedProperty _rotationSpeed;

        void OnEnable()
        {
            _target = serializedObject.FindProperty("target");
            _interpolator = serializedObject.FindProperty("interpolator");
            _positionSpeed = serializedObject.FindProperty("positionSpeed");
            _rotationSpeed = serializedObject.FindProperty("rotationSpeed");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_target);
            EditorGUILayout.PropertyField(_interpolator);
            EditorGUILayout.PropertyField(_positionSpeed);
            EditorGUILayout.PropertyField(_rotationSpeed);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
