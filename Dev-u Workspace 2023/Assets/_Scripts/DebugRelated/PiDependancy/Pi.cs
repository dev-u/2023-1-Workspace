using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pi
{
    public float pi = 3.14159f;
    private float multipliedPi = 1f;

    public void Multiply(float value)
    {
        multipliedPi *= pi * value;
    }


    public bool IsMultipliedPiLessThanValue(float value)
    {
        return multipliedPi < value;
    }

}
