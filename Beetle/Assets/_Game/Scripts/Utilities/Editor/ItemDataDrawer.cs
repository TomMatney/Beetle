using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemDataPreviewAttribute))]
public class ItemDataPreviewDrawer : PropertyDrawer
{

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.objectReferenceValue == null)
        {
            return base.GetPropertyHeight(property, label);
        }
        else
        {
            return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight*4f;
        }
    }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // First get the attribute since it contains the range for the slider
        ItemDataPreviewAttribute itemDataPreviewAttribute = attribute as ItemDataPreviewAttribute;

        Rect label1 = new Rect(position);
        label1.height -= EditorGUIUtility.singleLineHeight;

        Rect label2 = new Rect(position);
        label2.height -= EditorGUIUtility.singleLineHeight;
        label2.y += EditorGUIUtility.singleLineHeight;

        if (fieldInfo.FieldType == typeof(ItemData))
        {
            var itemData = (ItemData)property.objectReferenceValue;

            Rect propertyRect = new Rect(position);
            if (itemData == null)
            {
                EditorGUI.PropertyField(propertyRect, property);
                return;
            }
            
            propertyRect.height -= EditorGUIUtility.singleLineHeight * 4f;
            EditorGUI.PropertyField(propertyRect, property);


            Rect previewRect = EditorGUI.IndentedRect(position);
            previewRect.height -= EditorGUIUtility.singleLineHeight;
            previewRect.y += EditorGUIUtility.singleLineHeight;
            //previewRect.width *= .8f;
            EditorGUI.HelpBox(previewRect, "", MessageType.Info);
            //EditorGUI.DrawRect(previewRect, Color.gray);

            //padding
            Rect previewRectPadding = new Rect(previewRect);
            previewRectPadding.x += 3f;
            previewRectPadding.y += 3f;
            previewRectPadding.width -= 6f;
            previewRectPadding.height -= 6f;

            Rect previewTextureRect = new Rect(previewRectPadding);
            previewTextureRect.width = previewTextureRect.height;
            EditorGUI.DrawPreviewTexture(previewTextureRect, itemData.Icon.texture);

            Rect previewInfoRect = new Rect(previewRectPadding);
            previewInfoRect.height = EditorGUIUtility.singleLineHeight;
            previewInfoRect.x += previewTextureRect.width;
            previewInfoRect.width -= previewTextureRect.width;
            EditorGUI.LabelField(previewInfoRect, "Name", itemData.Name);
            previewInfoRect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(previewInfoRect, "Description", itemData.Description);
            previewInfoRect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(previewInfoRect, "Tags", string.Join(", ", itemData.Tags));
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use ItemDataPreview with ItemData.");
        }
    }
}
