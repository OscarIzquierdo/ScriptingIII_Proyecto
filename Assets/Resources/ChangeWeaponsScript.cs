using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponsScript : MonoBehaviour
{

    public GameObject prefabPistol;
    public GameObject prefabShotGun;
    public GameObject prefabAK;
    public GameObject prefabRPG;
    public GameObject prefabM320;
    int currentWeapon;
    public List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    { 
        weapons[4] = prefabAK;
        weapons[3] = prefabPistol;
        weapons[2] = prefabShotGun;
        weapons[1] = prefabRPG; 
        weapons[0] = prefabM320;
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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CheckWeapon(4);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && currentWeapon < 4)
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
            print(weapons[i]);
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
