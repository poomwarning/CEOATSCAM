using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lab2Object", menuName = "ScriptableObject/Create/Lab2Object")]
public class Lab2ScriptableObject : ScriptableObject
{
    [Header("Object")]
    public string objectName;
    public float objectMass;
    public float objectVolume;
    public float objectRho;
    
    [Header("Drowingobject")]
    public float drowingObjectMass;
    public float drowingObjectVolume;
    
    [Header("Liquid")]
    public string liquidName;
    public float liquidRho;
    public float overflowLiquidMass;

    [Header("Buoyantforce")]
    public float Buoyantforce;
}
