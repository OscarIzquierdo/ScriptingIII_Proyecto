using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacState : StateMachineBehaviour
{

    private Transform m_playerTransform;
    private UnityEngine.AI.NavMeshAgent m_agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        m_agent.isStopped = true;

    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransform.position);

        if (hearingDistance > 3)
        {
            animator.SetTrigger("Chase");
        }

        m_agent.SetDestination(m_playerTransform.position);

    }
}
