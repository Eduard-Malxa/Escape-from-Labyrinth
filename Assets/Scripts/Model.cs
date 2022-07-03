using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model : MonoBehaviour
{
    [SerializeField]
    private Color meshColor;

    [SerializeField]
    private HumanoidModel humanoidModel;
    public HumanoidModel HumanoidModel => humanoidModel;

    protected void ActivateHumanoidModel()
    {
        humanoidModel.GetSkinMaterials(meshColor);
    }
}
