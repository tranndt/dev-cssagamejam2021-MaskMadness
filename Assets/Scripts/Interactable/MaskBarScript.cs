using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskBarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMask(float maskValue)
    {
        slider.maxValue = maskValue;
        slider.value = maskValue;
    }

    public void SetMask(float maskValue)
    {
        slider.value = maskValue;
    }
}
