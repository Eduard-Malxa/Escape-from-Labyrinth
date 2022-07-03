using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private Transform[] waypoints;

    private int waypointIndex;

    private Vector3 target;

    [SerializeField]
    private bool patrolAccess;

    [SerializeField]
    private bool isPatrolBehaviour;
    public bool IsPatrolBehaviour => isPatrolBehaviour;

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    public void StartPatrol()
    {
        patrolAccess = true;
        UpdateDestination();
    }

    public void StopPatrol()
    {
        patrolAccess = false;
    }

    private void UpdateDestination()
    {
        if (patrolAccess)
        {
            target = waypoints[waypointIndex].position;
            navMeshAgent.SetDestination(target);
        }
    }

    private void IterateWaypointIndex()
    {
        if (patrolAccess)
        {
            waypointIndex++;
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }
}
