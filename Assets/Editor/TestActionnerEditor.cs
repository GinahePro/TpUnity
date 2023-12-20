using Codice.CM.SEIDInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Script.Behaviour;

[CustomEditor(typeof(TestActionner))]
public class TestActionnerEditor : Editor
{
    string test = "Activate";
    public override void OnInspectorGUI()
    {
        TestActionner testActionner = target as TestActionner;
        if (testActionner.State)
        {
            test = "Desactivate";
        }
        else
        {
            test = "Activate";
        }

        if (GUILayout.Button(test))
        {
            testActionner.SwitchState();
        }
    }
}
