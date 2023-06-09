using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterMeterScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxWater (float water)
    {
        slider.maxValue = water;
        slider.value = water;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetWater (float water)
    {
        slider.value = water;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
