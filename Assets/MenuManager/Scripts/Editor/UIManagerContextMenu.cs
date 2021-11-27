using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManagerContextMenu : Editor
{
    [MenuItem("GameObject/UI Manager/UI Elements/Button/Icon and Text Button", false, 1)]
    private static void IconAndTextButtonTemplate()
    {
        CreateTemplate("ButtonTemplates/BaseButton", "IconAndTextButton");
    }
    
    [MenuItem("GameObject/UI Manager/UI Elements/Button/Icon Button", false, 2)]
    private static void IconButtonTemplate()
    {
        CreateTemplate("ButtonTemplates/IconButton", "IconButton");
    }
    
    [MenuItem("GameObject/UI Manager/UI Elements/Button/Text Button", false, 3)]
    private static void TextButtonTemplate()
    {
        CreateTemplate("ButtonTemplates/TextButton", "TextButton");
    }
    
    private static void CreateTemplate(string path, string name)
    {
        GameObject template = Resources.Load(path) as GameObject;
        
        if (template != null)
        {
            Transform parent = Selection.activeGameObject.transform;
            GameObject instantiated = Instantiate(template, parent);
            instantiated.name = name;
        }
    }
}
