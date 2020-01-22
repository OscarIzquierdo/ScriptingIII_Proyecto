﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateWeaponList
{

    [MenuItem("Assets/Create/Weapon List")]
    public static WeaponList Create()
    {
        WeaponList asset = ScriptableObject.CreateInstance<WeaponList>();
        AssetDatabase.CreateAsset(asset, "Assets/WeaponList.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
