using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIDController
{
    private float kP, kI, kD; // The gain values
    private float p, i, d; // The propotional, integral & the derivates values
    
    public float Kp
    {
        get
        {
            return kP;
        }
        set
        {
            kP = value;
        }
    }
    
    public float Ki
    {
        get
        {
            return kI;
        }
        set
        {
            kI = value;
        }
    }

    public float Kd
    {
        get
        {
            return kD;
        }
        set
        {
            kD = value;
        }
    }
    private float previousError;

    public PIDController(float p, float i, float d)
    {
        kP = p;
        kI = i;
        kD = d;
    }

    public float GetOutput(float currentError, float deltaTime)
    {
        p = currentError;
        i += p * deltaTime;
        d = (p - previousError) / deltaTime;
        previousError = currentError;

        return p * kP + i * kI + d * kD;
    }

}
