using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStat(int stat)
    {
        slider.maxValue = stat;
        slider.value = stat;
    }

    public void SetStat(int stat)
    {
        slider.value = stat;
    }
}