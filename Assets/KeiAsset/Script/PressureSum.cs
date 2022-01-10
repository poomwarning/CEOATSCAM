using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSum : MonoBehaviour
{
    public float Pressure = 0;
    LiquidObject[] Liquidobject;

    // Update is called once per frame
    void Update()
    {
        Liquidobject = GetComponentsInChildren<LiquidObject>();
        Pressure = 0;
        if(Liquidobject != null)
        {
            for (int count = 0; count <= Liquidobject.Length - 1; count++) 
            {
                Pressure += Liquidobject[count].Pressure;
            }
        }
    }
}
