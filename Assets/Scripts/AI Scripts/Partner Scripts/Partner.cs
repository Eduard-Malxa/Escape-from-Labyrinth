using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Partner : Model
{
    [SerializeField]
    private FieldOfView fieldOfView;
    public FieldOfView FieldOfView => fieldOfView;

    [SerializeField]
    private AIMovement aIMovement;

    [SerializeField]
    private PartnersInformationUI partnersInformationUI;
    public void GetInformationUI(PartnersInformationUI value)
    {
        partnersInformationUI = value;
    }

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private bool infiniteChasingPlayer;

    [SerializeField]
    private bool playerInserted;

    private void Start()
    {
        ActivateHumanoidModel();
        partnersInformationUI.AddPartner();
    }

    private void Update()
    {
        if (fieldOfView.CanSeePlayer)
        {
            if (!playerInserted)
            {
                partnersInformationUI.RecognizePartnerWith();
                infiniteChasingPlayer = true;
                playerInserted = true;
            }
        }

        if (infiniteChasingPlayer)
        {
            HumanoidModel.Run();
            aIMovement.RunSpeed();
            aIMovement.ChasePlayer();
        }

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            HumanoidModel.Idle();
            aIMovement.StopSpeed();
        }
    }
}
