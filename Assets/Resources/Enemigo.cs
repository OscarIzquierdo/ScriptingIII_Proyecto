using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    public int vidaMaxima = 100;
    public int vidaActual;
    int wayPointActual;
    public List<GameObject> wayPoints;
    NavMeshAgent nmAgentCmp;
    // Use this for initialization
    void Start()
    {
        vidaActual = vidaMaxima;
        GetComponent<Renderer>().material.color = Color.white;
        wayPointActual = 0;
        nmAgentCmp = this.GetComponent<NavMeshAgent>();
        nmAgentCmp.SetDestination(wayPoints[0].transform.position);
    }

    public void QuitarVida(int daño)
    {
        vidaActual -= daño;

        float porcentajeVida = (float)vidaActual / vidaMaxima;
        Color color = new Color(1, porcentajeVida, porcentajeVida);
        this.GetComponent<Renderer>().material.color = color;

        if (vidaActual <= 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log("Me han quitao");
    }
    private void Update()
    {
        print(wayPoints.Count);
        if(nmAgentCmp.remainingDistance < 1 && !nmAgentCmp.pathPending)
        {
            NextWayPoint();
        }
    }
    void NextWayPoint()
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
            
    }
}