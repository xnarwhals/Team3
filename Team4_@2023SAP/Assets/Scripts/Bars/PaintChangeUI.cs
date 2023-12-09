using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintChangeUI : MonoBehaviour
{
    public Slider paintBarSlider;

    public float StartValue = 32.0f;
    public float EndValue = 32.0f;

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
        float value = (EndValue - StartValue) * (paint * 0.01f) + StartValue;
        paintBarSlider.value = value;
    }
}
