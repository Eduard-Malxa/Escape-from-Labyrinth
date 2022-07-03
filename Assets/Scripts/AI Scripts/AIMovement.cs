using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private FieldOfView fieldOfView;

    [SerializeField]
    private float walkSpeed = 1.5f;

    [SerializeField]
    private float runSpeed = 4f;

    [SerializeField]
    private float fastRunSpeed = 6f;

    public void ChasePlayer()
    {
        navMeshAgent.SetDestination(fieldOfView.Player.transform.position);
    }

    public void WalkSpeed()
    {
        navMeshAgent.speed = walkSpeed;
    }

    public void RunSpeed()
    {
        navMeshAgent.speed = runSpeed;
    }

    public void FastRunSpeed()
    {
        navMeshAgent.speed = fastRunSpeed;
    }

    public void StopSpeed()
    {
        navMeshAgent.speed = 0;
    }
}
