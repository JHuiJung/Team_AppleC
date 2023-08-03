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
        _editor.howMany = (InteractionHowMany)EditorGUILayout.EnumPopup("»ç¿ëÈ½¼ö", _editor.howMany);
        EditorGUILayout.Space();
        _editor.function = (InteractionFunction)EditorGUILayout.EnumPopup("±â´É", _editor.function);
        if (_editor.function == InteractionFunction.Move)
        {
            _editor.x = EditorGUILayout.FloatField("X ÁÂÇ¥", _editor.x);
            _editor.y = EditorGUILayout.FloatField("y ÁÂÇ¥", _editor.y);
        }
        else
        {

        }
    }
}
