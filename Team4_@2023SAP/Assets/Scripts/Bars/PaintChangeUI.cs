using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintChangeUI : MonoBehaviour
{
    public Slider paintBarSlider;

    public float StartValue = 32.0f;

    public void Start()
    {
        paintBarSlider = GetComponent<Slider>();

    }

    public void SetMaxPaint(float maxPaint)
    {
        paintBarSlider.maxValue = maxPaint;
        paintBarSlider.value = maxPaint;
    }

    public void SetPaint(float paint)
    {
        float value = paint * 0.01f * (100.0f - StartValue) + StartValue; //make paint a percentage, multiply by the amount of the bar that can be changed, add StartValue
        paintBarSlider.value = value;
    }
}
