using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ExpoDataGenerator))]
public class SceneStructureGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        ExpoDataGenerator expoDataGenerator = (ExpoDataGenerator)target;
        if(GUILayout.Button("Generate Expo Structure File"))
        {
            expoDataGenerator.generateExpoModeFile();
        }
    }
}
