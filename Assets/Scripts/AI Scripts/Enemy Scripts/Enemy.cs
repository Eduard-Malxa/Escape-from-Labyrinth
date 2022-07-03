using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Model
{
    [SerializeField]
    private FieldOfView fieldOfView;
    public FieldOfView FieldOfView => fieldOfView;

    [SerializeField]
    private Patrol patrol;

    [SerializeField]
    private AIMovement aIMovement;

    [SerializeField]
    private EnemyProgressBarUI progressBarUI;

    public void GetProgressBar(EnemyProgressBarUI value)
    {
        progressBarUI = value;
    }

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        ActivateHumanoidModel();
    }

    private void Update()
    {
        if (patrol.IsPatrolBehaviour)
        {
            if (fieldOfView.CanSeePlayer)
            {
                progressBarUI.SlideMeter(navMeshAgent.remainingDistance, fieldOfView.Radius);

                patrol.StopPatrol();
                HumanoidModel.Run();
                aIMovement.RunSpeed();
                aIMovement.ChasePlayer();
            }
            else
            {
                patrol.StartPatrol();
                HumanoidModel.Walk();
                aIMovement.WalkSpeed();
            }
        }
        else
        {
            if (fieldOfView.CanSeePlayer)
            {
                progressBarUI.SlideMeter(navMeshAgent.remainingDistance, fieldOfView.Radius);

                HumanoidModel.Run();
                aIMovement.RunSpeed();
                aIMovement.ChasePlayer();
            }
            else
            {
                HumanoidModel.Idle();
                aIMovement.StopSpeed();
            }
        }


        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            HumanoidModel.Idle();
            aIMovement.StopSpeed();
        }
    }
}

