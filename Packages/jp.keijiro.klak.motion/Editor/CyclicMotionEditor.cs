using UnityEngine;
using UnityEditor;

namespace Klak.Motion {

[CanEditMultipleObjects, CustomEditor(typeof(CyclicMotion))]
sealed class CyclicMotionEditor : Editor
{
    SerializedProperty _positionAmount;
    SerializedProperty _rotationAmount;
    SerializedProperty _frequency;

    static class Styles
    {
        public static readonly GUIContent position = new GUIContent("Position");
        public static readonly GUIContent rotation = new GUIContent("Rotation");
    }

    void OnEnable()
    {
        _positionAmount = serializedObject.FindProperty("PositionAmount");
        _rotationAmount = serializedObject.FindProperty("RotationAmount");
        _frequency = serializedObject.FindProperty("Frequency");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Amount");
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(_positionAmount, Styles.position);
        EditorGUILayout.PropertyField(_rotationAmount, Styles.rotation);
        EditorGUI.indentLevel--;

        EditorGUILayout.PropertyField(_frequency);

        serializedObject.ApplyModifiedProperties();
    }
}

} // namespace Klak.Motion
