using UnityEngine;
using UnityEditor;

namespace Klak.Motion
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(LinearMotion))]
    sealed class LinearMotionEditor : Editor
    {
        SerializedProperty _velocity;
        SerializedProperty _angularVelocity;

        void OnEnable()
        {
            _velocity = serializedObject.FindProperty("velocity");
            _angularVelocity = serializedObject.FindProperty("angularVelocity");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_velocity);
            EditorGUILayout.PropertyField(_angularVelocity);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
