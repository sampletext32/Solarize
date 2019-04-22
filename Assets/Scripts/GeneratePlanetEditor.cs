using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[CustomEditor(typeof(GeneratePlanet))]
public class GeneratePlanetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GeneratePlanet myScript = (GeneratePlanet) target;
        if (GUILayout.Button("Create Planet"))
        {
            myScript.CreatePlanet();
        }
    }
}

#endif