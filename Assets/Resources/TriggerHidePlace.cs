using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHidePlace : MonoBehaviour
{

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            player.SetHidden(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetHidden(false);

        }
    }
}
