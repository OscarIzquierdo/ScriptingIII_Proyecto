using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class EnemyGuardado : MonoBehaviour
{
    void Save()
    {
        JSONObject enemyJason = new JSONObject();

        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);

        enemyJason.Add("Position", position);

        //Save in computer

        string path = "Assets/ProyectoFinal/Scripts/Guardado/EnemySaveFile.json";
        File.WriteAllText(path, enemyJason.ToString());
    }

    void Load()
    {
        string path = "Assets/ProyectoFinal/Scripts/Guardado/EnemySaveFile.json";
        string jsonString = File.ReadAllText(path);
        JSONObject enemyJason = (JSONObject)JSON.Parse(jsonString);

        transform.position = new Vector3(
            enemyJason["Position"].AsArray[0],
            enemyJason["Position"].AsArray[1],
            enemyJason["Position"].AsArray[2]
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
