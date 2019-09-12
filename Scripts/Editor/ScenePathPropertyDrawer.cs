using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GeoTetra.GTCommon.Attributes
{
    [CustomPropertyDrawer(typeof(ScenePathAttribute))]
    public class ScenePathAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                if (property.isArray && 0 == String.CompareOrdinal("string", property.arrayElementType.ToLower()))
                {
                    for (int i = 0; i < property.arraySize; i++)
                    {
                        SceneField(position, property.GetArrayElementAtIndex(i));
                        position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    }
                }
                else
                {
                    SceneField(position, property);
                }
            }
            else
            {
                Color c = GUI.color;
                GUI.color = Color.red;
                GUI.Label(position, $"ScenePath attribute invalid for {property.propertyType}s!");
                GUI.color = c;
            }
        }

        private void SceneField(Rect position, SerializedProperty property)
        {
            SceneAsset sceneAsset = null;
            if (!string.IsNullOrEmpty(property.stringValue))
            {
                sceneAsset = AssetDatabase.LoadAssetAtPath(property.stringValue, typeof(SceneAsset)) as SceneAsset;
            }
            SceneAsset newScene = EditorGUI.ObjectField(position, "Scene:", sceneAsset, typeof(SceneAsset), false) as SceneAsset;
            property.stringValue = null == newScene ? string.Empty : AssetDatabase.GetAssetPath(newScene);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}