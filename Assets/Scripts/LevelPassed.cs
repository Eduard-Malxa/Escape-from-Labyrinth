using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            MenuUI.LevelPassed();
        }
    }
}
