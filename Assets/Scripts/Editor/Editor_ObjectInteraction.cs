using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectInteraction))]
public class Editor_ObjectInteraction : Editor
{
    ObjectInteraction _editor;
    void OnEnable()
    {
        _editor = target as ObjectInteraction;
    }

    public override void OnInspectorGUI()
    {
        _editor.howMany = (InteractionHowMany)EditorGUILayout.EnumPopup("���Ƚ��", _editor.howMany);
        EditorGUILayout.Space();
        _editor.function = (InteractionFunction)EditorGUILayout.EnumPopup("���", _editor.function);
        if (_editor.function == InteractionFunction.Move)
        {
            _editor.x = EditorGUILayout.FloatField("X ��ǥ", _editor.x);
            _editor.y = EditorGUILayout.FloatField("y ��ǥ", _editor.y);
        }
        else
        {

        }
    }
}
