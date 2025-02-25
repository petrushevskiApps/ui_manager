using System;
using System.Collections.Generic;
using System.Linq;
using com.petrushevskiapps.menumanager;
using PetrushevskiApps.UIManager;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(UIToggle), true)]
[CanEditMultipleObjects]
public class UIToggleEditor : ToggleEditor
{
    private readonly List<string> _extensionNames = new();

    private List<Type> _extensions = new();
    private GameObject _gameObject;

    protected override void OnEnable()
    {
        base.OnEnable();
        var buttonObject = (Toggle) target;
        _gameObject = buttonObject.gameObject;
        SetExtensions();
    }

    private void SetExtensions()
    {
        var types = AppDomain.CurrentDomain.GetAllDerivedTypes(typeof(SelectableExtension));

        if (types.Length != _extensions.Count)
        {
            _extensions.Clear();
            _extensionNames.Clear();

            _extensions = types.ToList();
            _extensionNames.Add("select");
            _extensions.ForEach(extension => _extensionNames.Add(extension.Name));
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        serializedObject.Update();

        DrawExtensionsWidgetInInspector();

        serializedObject.ApplyModifiedProperties();
    }


    private void DrawExtensionsWidgetInInspector()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Extensions", EditorStyles.boldLabel);
        var rect = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight);
        rect = EditorGUI.PrefixLabel(rect, new GUIContent("Add Extension"));

        var selection = EditorGUI.Popup(rect, 0, _extensionNames.ToArray());

        if (selection > 0)
        {
            var extType = _extensions[selection - 1];

            if (_gameObject.GetComponent(extType) == null) Undo.AddComponent(_gameObject, extType);
        }
    }
}