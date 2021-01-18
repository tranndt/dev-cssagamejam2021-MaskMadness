using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ISBarScript : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetMaxImSys(float systemLevel)
    {
        slider.maxValue = systemLevel;
        slider.value = systemLevel;
    }

    public void SetIm(float systemLevel)
    {
        slider.value = systemLevel;
    }
    
}
