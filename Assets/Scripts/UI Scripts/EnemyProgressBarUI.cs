using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyProgressBarUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void SlideMeter(float value, float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = value;

        if (slider.value == slider.maxValue)
            CloseSlider();
        else
            OpenSlider();
    }

    public void CloseSlider()
    {
        slider.gameObject.SetActive(false);
    }

    public void OpenSlider()
    {
        slider.gameObject.SetActive(true);
    }
}
