using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPaint 
{   //Logic for chaning the data of paint bar
    //Changing the UI is done via a different script
    float curPaint;
    float maxPaint;
    float regenPaintSpeed;
    bool pausePaintRegen = false;


    public float Paint
    {
        get
        {
            return curPaint;
        }
        set
        {
            curPaint = value;
        }
    }

    public float MaxPaint
    {
        get
        {
            return maxPaint;
        }
        set
        {
            maxPaint = value;
        }
    }

    public float RegenPaintSpeed
    {
        get
        {
            return regenPaintSpeed;
        }
        set
        {
            regenPaintSpeed = value;
        }
    }

    public  bool PausePaintRegen
    {
        get
        {
            return pausePaintRegen;
        }
        set
        {
            pausePaintRegen = value;
        }
    }

    public UnitPaint(float Paint,float maximumPaint, float regenSpeed, bool pauseRegen)
    {
        curPaint = Paint;
        maxPaint = maximumPaint;
        regenPaintSpeed = regenSpeed;
        pausePaintRegen = pauseRegen;

    }

    public void UsePaint(float paintAmount)
    {
        if(curPaint > 0)
        {
            curPaint -= paintAmount;
        }
    }

    public void RegenPaint()
    {
        if (curPaint < maxPaint && !pausePaintRegen)
        {
            curPaint += regenPaintSpeed * Time.deltaTime;
        }
    }






}
