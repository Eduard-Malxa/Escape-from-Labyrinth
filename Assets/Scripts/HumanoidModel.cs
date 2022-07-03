using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidModel : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer[] skinnedMeshRenderer;

    [SerializeField]
    private Animator animator;
    public Animator Animator => animator;

    private string Behavior = "Behavior";

    public void GetSkinMaterials(Color color)
    {
        for (int i = 0; i < skinnedMeshRenderer.Length; i++)
        {
            for (int j = 0; j < skinnedMeshRenderer[i].materials.Length; j++)
            {
                skinnedMeshRenderer[i].materials[j].color = color;
            }
        }
    }

    public void Run()
    {
        animator.SetInteger(Behavior, 2);
    }

    public void Walk()
    {
        animator.SetInteger(Behavior, 1);
    }

    public void Idle()
    {
        animator.SetInteger(Behavior, 0);
    }
}
