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

[CustomEditor(typeof(ReaktorToAnimator)), CanEditMultipleObjects]
public class ReaktorToAnimatorEditor : Editor
{
    SerializedProperty propEnableSpeed;
    SerializedProperty propSpeedCurve;

    SerializedProperty propEnableTrigger;
    SerializedProperty propTriggerThreshold;
    SerializedProperty propTriggerInterval;
    SerializedProperty propTriggerName;

    GUIContent labelSpeed;
    GUIContent labelCurve;
    GUIContent labelTrigger;
    GUIContent labelThreshold;
    GUIContent labelInterval;

    void OnEnable()
    {
        propEnableSpeed = serializedObject.FindProperty("enableSpeed");
        propSpeedCurve  = serializedObject.FindProperty("speedCurve");

        propEnableTrigger    = serializedObject.FindProperty("enableTrigger");
        propTriggerThreshold = serializedObject.FindProperty("triggerThreshold");
        propTriggerInterval  = serializedObject.FindProperty("triggerInterval");
        propTriggerName      = serializedObject.FindProperty("triggerName");

        labelSpeed     = new GUIContent("Speed");
        labelCurve     = new GUIContent("Curve");
        labelTrigger   = new GUIContent("Trigger");
        labelThreshold = new GUIContent("Threshold");
        labelInterval  = new GUIContent("Minimum Interval");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(propEnableSpeed, labelSpeed);

        if (propEnableSpeed.hasMultipleDifferentValues || propEnableSpeed.boolValue)
        {
            EditorGUILayout.PropertyField(propSpeedCurve, labelCurve);
            EditorGUILayout.Space();
        }

        EditorGUILayout.PropertyField(propEnableTrigger, labelTrigger);

        if (propEnableTrigger.hasMultipleDifferentValues || propEnableTrigger.boolValue)
        {
            EditorGUILayout.Slider(propTriggerThreshold, 0.0f, 1.0f, labelThreshold);
            EditorGUILayout.PropertyField(propTriggerInterval, labelInterval);
            EditorGUILayout.PropertyField(propTriggerName);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
