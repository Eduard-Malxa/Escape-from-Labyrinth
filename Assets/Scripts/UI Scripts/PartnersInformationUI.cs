using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PartnersInformationUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI partnersAllCountText;

    [SerializeField]
    private TextMeshProUGUI partnersWithCountText;

    [SerializeField]
    private int allPartnersCount;
    public int AllPartnersCount
    {
        get => allPartnersCount;
        set
        {
            allPartnersCount = value;
            partnersAllCountText.text = allPartnersCount.ToString();
        }
    }

    [SerializeField]
    private int withPartnersCount;
    public int WithPartnersCount
    {
        get => withPartnersCount;
        set
        {
            withPartnersCount = value;
            partnersWithCountText.text = withPartnersCount.ToString();
        }
    }

    private void Awake()
    {
        WithPartnersCount = 0;
        AllPartnersCount = 0;
    }

    public void RecognizePartnerWith()
    {
        WithPartnersCount++;
    }

    public void AddPartner()
    {
        AllPartnersCount++;
    }
}
