using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Unity;

public class MaskBarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMask(int maskValue)
    {
        slider.maxValue = maskValue;
        slider.value = maskValue;
    }

    public void SetMask(int maskValue)
    {
        slider.value = maskValue;
    }
}
