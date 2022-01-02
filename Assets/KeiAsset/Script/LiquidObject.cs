using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidObject : MonoBehaviour
{
    [Header("pho in kg/m^3 Unit")]
    public float pho;
    [Header("Height in cm Unit")]
    public float Height;
    [Header("Set Height by scale(T) or Set scale ny Height(F)")]
    public bool Setmode = true;
    [Header("Pressure in pascal Unit")]
    public float Pressure;

    // Update is called once per frame
    void Update()
    {
        if (Setmode == true)
        {
            Height = (transform.localScale.y - 0.01f) * 100;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, ((Height / 100) + 0.01f), transform.localScale.z);
        }
        Pressure = pho * (Height/100) * 9.8f;
    }
}
