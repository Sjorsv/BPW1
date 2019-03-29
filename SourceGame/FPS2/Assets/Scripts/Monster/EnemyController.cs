using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public PlayerManager playerManager;
    Transform target;
    NavMeshAgent agent;
    private bool idle;
    private bool awake;
  
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

        }
        //if (distance >= lookRadius)
        //{

        //}
    }

    //void IdleMob ()
    //{
    //    if idle 
    //}

    //void AwakeMob()
    //{

    //}
    void OnDrawGizmosSelected () // use gizmos as debugging to outline radiuses 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
