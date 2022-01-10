using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lab2Object", menuName = "ScriptableObject/Create/Lab2Object")]
public class Lab2ScriptableObject : ScriptableObject
{
    [Header("Object")]
    public string objectName;
    public float objectWeight;
    public float objectVolume;
    public float objectRho;
    
    [Header("Drowingobject")]
    public float drowingObjectWeight;
    public float drowingObjectVolume;
    
    [Header("Liquid")]
    public string liquidName;
    public float liquidRho;
    public float overflowLiquidWeight;

    [Header("Buoyantforce")]
    public float Buoyantforce;
}
