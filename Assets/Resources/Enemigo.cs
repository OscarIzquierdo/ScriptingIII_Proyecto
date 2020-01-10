using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    public int vidaMaxima = 100;
    public int vidaActual;
    Animator animatorCmp;
    
    //int wayPointActual;
    //public List<GameObject> wayPoints;
    NavMeshAgent nmAgentCmp;
    // Use this for initialization
    void Start()
    {
        animatorCmp = this.GetComponent<Animator>();
        vidaActual = vidaMaxima;
        //GetComponent<Renderer>().material.color = Color.white;
        //wayPointActual = 0;
        nmAgentCmp = this.GetComponent<NavMeshAgent>();
        //nmAgentCmp.SetDestination(wayPoints[0].transform.position);
    }

    public void QuitarVida(int daño)
    {
        vidaActual -= daño;

        float porcentajeVida = (float)vidaActual / vidaMaxima;
        //Color color = new Color(1, porcentajeVida, porcentajeVida);
        //this.GetComponent<Renderer>().material.color = color;

        if (vidaActual <= 0)
        {
            nmAgentCmp.speed = 0;
            animatorCmp.SetTrigger("Dead");
        }

        Debug.Log("Me han quitao");
    }
    private void Update()
    {

        print(vidaActual);
        /*
        if(nmAgentCmp.remainingDistance < 1 && !nmAgentCmp.pathPending)
        {
            NextWayPoint();
        }*/
    }
    /*void NextWayPoint()
    {
        if(wayPointActual < wayPoints.Count - 1)
        {

            wayPointActual = wayPointActual + 1;
            print("Cambie de waypoint a" + wayPointActual);
            nmAgentCmp.SetDestination(wayPoints[wayPointActual].transform.position);
        }
        else
        {
            wayPointActual = 0;
            nmAgentCmp.SetDestination(wayPoints[wayPointActual].transform.position);
        }
            
    }*/
}