using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerScript : MonoBehaviour
{
    [Header("Overflow Water")]
    [Range(-0.5f,0f)]
    public float waterLevel;
    public Material waterShader;

    // Update is called once per frame
    void Update()
    {
        SetWaterLevel();
    }

    void SetWaterLevel(){
        waterShader.SetFloat("_waterLevel",waterLevel);
    }
}
