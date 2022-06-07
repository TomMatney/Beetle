using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct MinMaxInt
{
    [SerializeField] public int min;
    [SerializeField] public int max;

    public MinMaxInt(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public int Random()
    {
        return UnityEngine.Random.Range(min, max+1);
    }
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(MinMaxInt))]
public class MinMaxIntDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var amountRect = new Rect(position.x, position.y, 35, position.height);
        var unitRect = new Rect(position.x + 40, position.y, 35, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("min"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("max"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

#endif