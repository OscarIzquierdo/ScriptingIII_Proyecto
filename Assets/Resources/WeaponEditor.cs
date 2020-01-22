using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponEditor : EditorWindow
{

    [MenuItem("Window/Weapon Editor")]
    
    static void Init()
    {
        EditorWindow.GetWindow(typeof(WeaponEditor));
    }

    private void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPatch")) 
        {
            string objectPath = "Assets/Resources/Data/WeaponList.asset";
            //inventoryItemList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(WeaponList));
        }
    }
}
