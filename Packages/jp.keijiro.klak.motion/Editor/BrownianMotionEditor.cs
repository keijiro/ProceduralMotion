using UnityEngine;
using UnityEditor;

namespace Klak.Motion
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BrownianMotion))]
    sealed class BrownianMotionEditor : Editor
    {
        SerializedProperty _positionAmount;
        SerializedProperty _rotationAmount;
        SerializedProperty _frequency;
        SerializedProperty _octaves;

        static class Styles
        {
            public static readonly GUIContent position = new GUIContent("Position");
            public static readonly GUIContent rotation = new GUIContent("Rotation");
        }

        void OnEnable()
        {
            _positionAmount = serializedObject.FindProperty("positionAmount");
            _rotationAmount = serializedObject.FindProperty("rotationAmount");
            _frequency = serializedObject.FindProperty("frequency");
            _octaves = serializedObject.FindProperty("octaves");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Noise Amount");
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_positionAmount, Styles.position);
            EditorGUILayout.PropertyField(_rotationAmount, Styles.rotation);
            EditorGUI.indentLevel--;

            EditorGUILayout.PropertyField(_frequency);
            EditorGUILayout.IntSlider(_octaves, 1, 9);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
