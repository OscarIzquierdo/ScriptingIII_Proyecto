using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Animator m_animator;
    private Transform m_playerTransf;
    private Player m_player;
    private UnityEngine.AI.NavMeshAgent m_agent;
    bool playerHidden = false;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_animator = animator;
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.isStopped = true;
        m_playerTransf = GameObject.FindGameObjectWithTag("Player").transform;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransf.position);
        playerHidden = m_player.GetHidden();

        if(hearingDistance < 10 && playerHidden != true)
        {
            animator.SetTrigger("Chase");
        }
    }
}
