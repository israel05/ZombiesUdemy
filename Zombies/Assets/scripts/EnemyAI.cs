using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 2f;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    
    float distanceToTarget = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }            
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {

            AttackTarget();
        }

    }
      

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false); //entra en la animacion attack
        GetComponent<Animator>().SetTrigger("move"); //entra en la animacion move
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true); //entra en la animacion attack
        //if (GetComponent<Animator>().GetBool("attack"))
        //{
        //    print("LANZO ANIMACION ATTACK");
       // }
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log(name + " esta atacando a " + target.name);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
