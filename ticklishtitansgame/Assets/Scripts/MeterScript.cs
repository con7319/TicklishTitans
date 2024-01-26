using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image Bar1;
    public Image Bar2;
    public Image Bar3;

    public float trigPer1 = 0f;
    public float trigPer2 = 40f;
    public float trigPer3 = 80f;

    public void SetHumour(int humour)
    {
        slider.minValue = 0; 
        slider.maxValue = 100; 
        slider.value = humour;
        UpdateGradientColor();
        UpdateImageVisibility();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void MeterF(int humour)
    {
        slider.value = humour;
        UpdateGradientColor();
        UpdateImageVisibility();
    }

    void UpdateGradientColor()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void UpdateImageVisibility()
    {
        float value = slider.value;

        Bar1.enabled = value >= trigPer1 && value < trigPer2;
        Bar2.enabled = value >= trigPer2 && value < trigPer3;
        Bar3.enabled = value >= trigPer3;
    }

    void OnSliderValueChanged(float value)
    {
        UpdateImageVisibility();
    }
}
