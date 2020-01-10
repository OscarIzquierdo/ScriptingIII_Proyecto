using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachineusingBehaviours : MonoBehaviour
{
    Animator m_animator;
    Player m_player;
    public bool playerHidden;
    CapsuleCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_player = GetComponent<Player>();
        coll = this.GetComponentInChildren<CapsuleCollider>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnIdleAnimCompleted()
    {
        m_animator.SetTrigger("Patrol");
        
    }

    public void ActivateCollider()
    {
        coll.enabled = true;
    }
    public void DesactivateCollider()
    {
        coll.enabled = false;
    }
}

