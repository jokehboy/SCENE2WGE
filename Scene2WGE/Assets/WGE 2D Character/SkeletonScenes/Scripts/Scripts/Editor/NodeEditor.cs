using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Flags]
public enum EditorListOptions
{
    None = 0,
    ListSize = 1,
    ListLabel = 2,
    ElementLabels = 4,
    Default = ListSize | ListLabel|ElementLabels,
    NoElementLabels = ListSize|ListLabel
}



[CustomEditor(typeof(NodeData)), CanEditMultipleObjects]
public class NodeEditor : Editor
{

    public SerializedProperty _ID;
    public SerializedProperty _NPCText;
    public SerializedProperty _PlayerResponse;
    public SerializedProperty _DestinationNode;


#if UNITY_EDITOR
    public string Name;
#endif
    private void OnEnable()
    {
        _ID = serializedObject.FindProperty("ID");

        _NPCText = serializedObject.FindProperty("NPCText");
        _PlayerResponse = serializedObject.FindProperty("responses");
        _DestinationNode = serializedObject.FindProperty("responseDestinationNodeID");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Biggg");
        NodeEditor.Show(_ID, EditorListOptions.Default);
        NodeEditor.Show(_NPCText, EditorListOptions.Default);
        NodeEditor.Show(_PlayerResponse, EditorListOptions.Default);
        NodeEditor.Show(_DestinationNode, EditorListOptions.Default);
        
        serializedObject.ApplyModifiedProperties();
    }

    public static void Show(SerializedProperty list, EditorListOptions options = EditorListOptions.Default)
    {
        bool
            showListLabel = (options & EditorListOptions.ListLabel) != 0,
            showListSize = (options & EditorListOptions.ListSize) != 0;

        if (showListLabel)
        {
            EditorGUILayout.PropertyField(list);
            EditorGUI.indentLevel += 1;
        }
        if (!showListLabel || list.isExpanded)
        {
            if (showListSize)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));

            }

            ShowElements(list, options);

        }
        if (showListLabel)
        {
            EditorGUI.indentLevel -= 1;

        }


    }
    private static void ShowElements(SerializedProperty list, EditorListOptions options)
    {
        bool showElementLabels = (options & EditorListOptions.ElementLabels) != 0;
        for (int i = 0; i < list.arraySize; i++)
        {
            if(showElementLabels)
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));

            }
            else
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);

            }
        }

    }

}