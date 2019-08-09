using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialougeManager))]
public class SaveLoadButtons : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Save"))
        {
            new NodeContainer().Save("Test.xml");
            new NodeContainer().Save("TestLoad.xml");
        }
        if (GUILayout.Button("Load"))
        {
            new NodeContainer().Load("TestLoad.xml");
        }
    }
}
