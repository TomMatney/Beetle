using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class ItemDropTable
{
    [System.Serializable]
    public class DropData
    {
        [Range(0f, 100f)]
        public float dropChance = 100f;

        public MinMaxInt amount = new MinMaxInt(1, 1);

        public ItemData itemData;
    }

    public DropData[] dropData;
}

//#if UNITY_EDITOR
//// DropDataDrawer
//[CustomPropertyDrawer(typeof(ItemDropTable.DropData))]
//public class DropDataDrawer : PropertyDrawer
//{
//    // Draw the property inside the given rect
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        // Using BeginProperty / EndProperty on the parent property means that
//        // prefab override logic works on the entire property.
//        EditorGUI.BeginProperty(position, label, property);

//        // Draw label
//        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

//        // Don't make child fields be indented
//        var indent = EditorGUI.indentLevel;
//        EditorGUI.indentLevel = 0;

//        // Calculate rects
//        var amountRect = new Rect(position.x, position.y, 50, position.height);
//        var unitRect = new Rect(position.x + 70, position.y, 50, position.height);
//        //var nameRect = new Rect(position.x + 100, position.y, position.width - 90, position.height);

//        // Draw fields - pass GUIContent.none to each so they are drawn without labels
//        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("dropChance"), new GUIContent("Drop %"));
//        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("amount"), GUIContent.none);
//        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("itemData"), GUIContent.none);

//        // Set indent back to what it was
//        EditorGUI.indentLevel = indent;

//        EditorGUI.EndProperty();
//    }
//}
//#endif
