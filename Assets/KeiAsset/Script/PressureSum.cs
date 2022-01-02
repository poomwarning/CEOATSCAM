using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSum : MonoBehaviour
{
    public float Pressure;
    LiquidObject[] Liquidobject;

    // Update is called once per frame
    void Update()
    {
        Liquidobject = GetComponentsInChildren<LiquidObject>();
        if(Liquidobject != null)
        {
            for(int count = 0;count <= Liquidobject.Length;count++)
            {
                Pressure = Liquidobject[count].Pressure;
            }
        }
    }
}
