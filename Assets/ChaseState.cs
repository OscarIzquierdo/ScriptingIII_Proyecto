using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateMachineBehaviour
{

    private Transform m_playerTransform;
    private UnityEngine.AI.NavMeshAgent m_agent;
    private Player m_player;
    private bool playerHidden = false; 

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_player = animator.gameObject.GetComponent<Enemigo>().ReturnPlayer();
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.isStopped = false;
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransform.position);
        playerHidden = m_player.GetHidden();


        if (hearingDistance < 1.5)
        {
            animator.SetTrigger("Attack");
        }

        if (hearingDistance > 14 || playerHidden == true)
        {
            animator.SetTrigger("Idle");
        }

        m_agent.SetDestination(m_playerTransform.position);
        Debug.Log(m_playerTransform.position);
    }

}
