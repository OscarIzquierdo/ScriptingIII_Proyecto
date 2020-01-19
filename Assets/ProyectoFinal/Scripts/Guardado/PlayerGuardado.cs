using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class PlayerGuardado : MonoBehaviour
{
    public VerySimplePistol pistol;
    public VerySimpleSMG rifle;

    void Save()
    {
        JSONObject playerJason = new JSONObject();
        playerJason.Add("PistolAmmo", pistol.currentAmmo);
        playerJason.Add("RifleAmmo", rifle.currentAmmo);


        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);

        playerJason.Add("Position", position);

        //Save in computer
        string path = "Assets/ProyectoFinal/Scripts/Guardado/PlayerSaveFile.json";
        File.WriteAllText(path, playerJason.ToString());

        Debug.Log(pistol.currentAmmo);
        Debug.Log(rifle.currentAmmo);
    }

    void Load()
    {
        string path = "Assets/ProyectoFinal/Scripts/Guardado/PlayerSaveFile.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerJason = (JSONObject)JSON.Parse(jsonString);

        pistol.currentAmmo = playerJason["PistolAmmo"];
        rifle.currentAmmo = playerJason["RifleAmmo"];

        transform.position = new Vector3(
            playerJason["Position"].AsArray[0],
            playerJason["Position"].AsArray[1],
            playerJason["Position"].AsArray[2]
            );
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Load();
        }
    }
}
