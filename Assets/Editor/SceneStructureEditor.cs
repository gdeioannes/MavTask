using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SceneStructure))]
public class SceneStructureGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        SceneStructure sceneStructure = (SceneStructure)target;
        if(GUILayout.Button("Create Strcuture File"))
        {
            sceneStructure.generateStructureFile();
        }
    }
}
