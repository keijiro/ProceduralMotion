using UnityEngine;
using UnityEditor;

namespace Klak.Motion
{
    static class Utilities
    {
        public static void ShowSeedField(SerializedProperty prop)
        {
            if (prop.hasMultipleDifferentValues ||
                prop.serializedObject.targetObjects.Length > 1)
            {
                EditorGUILayout.PropertyField(prop);
                return;
            }

            EditorGUI.BeginChangeCheck();

            var seed = prop.intValue;
            var flag = EditorGUILayout.Toggle("Set Seed", seed > 0);

            if (flag)
            {
                EditorGUI.indentLevel++;
                seed = Mathf.Max(1, EditorGUILayout.IntField("Seed", seed));
                EditorGUI.indentLevel--;
            }

            if (EditorGUI.EndChangeCheck()) prop.intValue = flag ? seed : 0;
        }
    }
}
