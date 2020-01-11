using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponsScript : MonoBehaviour
{

    public GameObject prefabPistol;
    public GameObject prefabShotGun;
    public GameObject prefabAK;
    int currentWeapon;
    public List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    { 
        weapons[0] = prefabAK;
        weapons[1] = prefabPistol;

        for (int i = 0; i < weapons.Count; i++)
        {
            
            if (weapons[i] == prefabPistol)
            {
                weapons[i].SetActive(true);
                currentWeapon = i;
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckWeapon(1);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && currentWeapon < 1)
        {
            CheckWeapon(currentWeapon + 1);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && currentWeapon > 0)
        {
            CheckWeapon(currentWeapon - 1 );
        }


    }
    void CheckWeapon(int indice)
    {

        for (int i = 0; i < weapons.Count; i++)
        {
            //print(weapons[i]);
            if (i == indice)
            {
                weapons[i].SetActive(true);
                //print("seteo como activo" + i);
                currentWeapon = i;
            }
            else
            {
                weapons[i].SetActive(false);
            }
        };
    }
}
