using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    private Transform m_playerTransform;
    private Transform[] m_waypointsVector;
    private UnityEngine.AI.NavMeshAgent m_agent;
    private Player m_player;
    bool playerHidden = false;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();

        GameObject[] waypointsVector = GameObject.FindGameObjectsWithTag("Waypoint");
        m_waypointsVector = new Transform[waypointsVector.Length];
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


        for (int i = 0; i < waypointsVector.Length; i++)
        {
            m_waypointsVector[i] = waypointsVector[i].transform;
        }

        Transform randomWaypoint = m_waypointsVector[Random.Range(0, m_waypointsVector.Length)];
        m_agent.isStopped = false;
        m_agent.SetDestination(randomWaypoint.position);

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransform.position);
        playerHidden = m_player.GetHidden();

        if (hearingDistance < 10 && playerHidden != true)
        {
            animator.SetTrigger("Chase");
        }

        if(m_agent.pathPending && m_agent.remainingDistance <1)
        {
            animator.SetTrigger("Idle");
        }
    }
}
