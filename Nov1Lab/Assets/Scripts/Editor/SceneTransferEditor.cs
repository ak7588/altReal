using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneTransfer))]

public class SceneTransferEditor : Editor
{
    SerializedProperty toScene;
    SerializedProperty changeLayer;
    SerializedProperty toLayer;

    private void OnEnable()
    {
        toScene = serializedObject.FindProperty("toScene");
        changeLayer = serializedObject.FindProperty("changeLayer");
        toLayer = serializedObject.FindProperty("toLayer");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(toScene);
        EditorGUILayout.PropertyField(changeLayer);
        if (changeLayer.boolValue) {
            int currLayer = toLayer.intValue;
            toLayer.intValue = EditorGUILayout.LayerField("To Layer: ", currLayer);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
