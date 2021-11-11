using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudBars : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxValueBars(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    
    public void SetValue(int value)
    {
        slider.value = value;
    }
}
