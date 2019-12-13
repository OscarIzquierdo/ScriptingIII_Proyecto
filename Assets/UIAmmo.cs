using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmo : MonoBehaviour
{
    public TextMeshPro tmPro;
    public TextMeshPro tmProHP;
    public int indiceAmmo;
    public float hp;
    // Start is called before the first frame update

    public void SetText(int i)
    {
        indiceAmmo = i;

    
    }
    public void SetHPText (int hpExt)
    {
        hp = hpExt;
    }
    private void Update()
    {
        print(indiceAmmo + " Ammo");
        tmPro.text = indiceAmmo + " Ammo";
        tmProHP.text = hp + "HP";
    }

}
