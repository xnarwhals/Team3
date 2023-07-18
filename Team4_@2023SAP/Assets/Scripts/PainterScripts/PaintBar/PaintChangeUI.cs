using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintChangeUI : MonoBehaviour
{
    public Slider paintBarSlider;

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
        paintBarSlider.value = paint;
    }




}
