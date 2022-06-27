using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LiquidSample",menuName ="LiquidSample")]
public class LiquidObj : ScriptableObject
{
    public string LiquidName;
    public float SurfaceTensionForce;
    public string liquidName
    {
        get { return LiquidName; }
    }
    public float STforce
    {
        get { return SurfaceTensionForce; }
    }


}
