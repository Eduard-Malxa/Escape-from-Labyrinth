using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    private Player player;
    public Player Player { get => player; set => player = value; }

    [SerializeField, Range(1, 10)]
    private float radius;
    public float Radius => radius;

    [SerializeField, Range(0, 360)]
    private float angle;
    public float Angle => angle;

    [SerializeField]
    private LayerMask playerMask;

    [SerializeField]
    private LayerMask obstructionMask;

    [SerializeField]
    private bool canSeePlayer;
    public bool CanSeePlayer => canSeePlayer;

    private void Update()
    {
        FieldOfViewCheck();
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, playerMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
