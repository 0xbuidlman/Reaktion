﻿//
// Reaktion - An audio reactive animation toolkit for Unity.
//
// Copyright (C) 2013, 2014 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Reaktion {

[CustomEditor(typeof(TurbulentMotion)), CanEditMultipleObjects]
public class TurbulentMotionEditor : Editor
{
    SerializedProperty propMaxDisplacement;
    SerializedProperty propMaxRotation;
    SerializedProperty propMinScale;

    SerializedProperty propFlowVector;
    SerializedProperty propFlowDensity;

    SerializedProperty propCoeffDisplacement;
    SerializedProperty propCoeffRotation;
    SerializedProperty propCoeffScale;

    SerializedProperty propUseLocalCoordinate;
    SerializedProperty propScaleByShader;
    SerializedProperty propScalePropertyName;
    
    void OnEnable()
    {
        propMaxDisplacement = serializedObject.FindProperty("maxDisplacement");
        propMaxRotation     = serializedObject.FindProperty("maxRotation");
        propMinScale        = serializedObject.FindProperty("minScale");

        propFlowVector  = serializedObject.FindProperty("flowVector");
        propFlowDensity = serializedObject.FindProperty("flowDensity");

        propCoeffDisplacement = serializedObject.FindProperty("coeffDisplacement");
        propCoeffRotation     = serializedObject.FindProperty("coeffRotation");
        propCoeffScale        = serializedObject.FindProperty("coeffScale");

        propUseLocalCoordinate = serializedObject.FindProperty("useLocalCoordinate");
        propScaleByShader      = serializedObject.FindProperty("scaleByShader");
        propScalePropertyName  = serializedObject.FindProperty("scalePropertyName");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Noise");
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(propFlowDensity, new GUIContent("Density"));
        EditorGUILayout.PropertyField(propFlowVector, new GUIContent("Linear Flow"));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Displacement");
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(propMaxDisplacement, new GUIContent("Amplitude"));
        EditorGUILayout.PropertyField(propCoeffDisplacement, new GUIContent("Wavenumber"));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Rotation (Euler)");
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(propMaxRotation, new GUIContent("Amplitude"));
        EditorGUILayout.PropertyField(propCoeffRotation, new GUIContent("Wavenumber"));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Scale");
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(propMinScale, new GUIContent("Influence (≦1.0)"));
        EditorGUILayout.PropertyField(propCoeffScale, new GUIContent("Wavenumber"));
        EditorGUILayout.PropertyField(propScaleByShader);
        if (propScaleByShader.hasMultipleDifferentValues || propScaleByShader.boolValue)
            EditorGUILayout.PropertyField(propScalePropertyName, new GUIContent("Property Name"));
        EditorGUI.indentLevel--;


        EditorGUILayout.PropertyField(propUseLocalCoordinate, new GUIContent("Local Coordinate"));

        serializedObject.ApplyModifiedProperties();
    }
}

} // namespace Reaktion
