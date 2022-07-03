using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupAI : MonoBehaviour
{
    [SerializeField]
    private PartnersInformationUI partnersInformationUI;

    [SerializeField]
    private EnemyProgressBarUI enemyProgress;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Enemy[] enemies;

    [SerializeField]
    private Partner[] partners;

    private void Start()
    {
        SetupEnemy();
        SetupPartner();
    }

    public void SetupEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetProgressBar(enemyProgress);
            enemies[i].FieldOfView.Player = player;
        }
    }

    public void SetupPartner()
    {
        for (int i = 0; i < partners.Length; i++)
        {
            partners[i].FieldOfView.Player = player;
            partners[i].GetInformationUI(partnersInformationUI);
        }
    }
}
