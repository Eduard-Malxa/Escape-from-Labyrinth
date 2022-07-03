using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private string Open = "Open";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Model model))
        {
            animator.SetBool(Open, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Model model))
        {
            animator.SetBool(Open, false);
        }
    }
}
