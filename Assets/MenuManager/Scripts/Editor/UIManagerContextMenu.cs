using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManagerContextMenu : Editor
{
    [MenuItem("GameObject/UI Manager/UI Elements/Button/Dynamic Size Button", false, 1)]
    private static void DynamicButtonTemplate()
    {
        CreateTemplate("ButtonTemplates/DynamicSizeButton", "DynamicSizeButton");
    }
    [MenuItem("GameObject/UI Manager/UI Elements/Button/Fix Size Button", false, 1)]
    private static void FixButtonTemplate()
    {
        CreateTemplate("ButtonTemplates/FixSizeButton", "FixSizeButton");
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
    
    
    [MenuItem("GameObject/UI Manager/UI Elements/Toggle/Icon and Text Toggle", false, 1)]
    private static void IconAndTextToggleTemplate()
    {
        CreateTemplate("ToggleTemplates/IconAndTextToggle", "IconAndTextToggle");
    }
    
    [MenuItem("GameObject/UI Manager/UI Elements/Toggle/Icon Toggle", false, 2)]
    private static void IconToggle()
    {
        CreateTemplate("ToggleTemplates/IconToggle", "IconToggle");
    }
    
    [MenuItem("GameObject/UI Manager/UI Elements/Toggle/TextToggle", false, 3)]
    private static void TextToggle()
    {
        CreateTemplate("ToggleTemplates/TextToggle", "TextToggle");
    }
    
    
    [MenuItem("GameObject/UI Manager/UI Elements/Label/Horizontal Label", false, 1)]
    private static void HorizontalLabel()
    {
        CreateTemplate("LabelTemplates/HorizontalLabel", "HorizontalLabel");
    }
    
    [MenuItem("GameObject/UI Manager/UI Elements/Label/Vertical Label", false, 1)]
    private static void VerticalLabel()
    {
        CreateTemplate("LabelTemplates/VerticalLabel", "VerticalLabel");
    }
    
    
    [MenuItem("GameObject/UI Manager/UI Windows/Popups/Base Popup", false, 1)]
    private static void BasePopup()
    {
        CreateTemplate("PopupTemplates/BasePopup", "BasePopup");
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
