using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScrip : MonoBehaviour
{
    bool firstHit = false;
    public GameObject shootSpot;
    public void ShootRPG(float speed)
    {

        GetComponent<Rigidbody>().velocity = (-transform.forward * speed);
        firstHit = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(firstHit == true)
        {

            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10);


            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(20, collision.transform.position, 10, 3.0F, ForceMode.Impulse);

                hit.transform.gameObject.SendMessage("QuitarVida", 10);

                Debug.Log("Hitted something I shall destroy myself");
            }


            shootSpot.GetComponent<ParticleSystem>().Play();
            DestroyGrenade();
            firstHit = false;
        }


    }
    private void DestroyGrenade()
    {
        if(firstHit == false)
        {
            shootSpot.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject, 2f);
        }

        firstHit = true;
    }


}
