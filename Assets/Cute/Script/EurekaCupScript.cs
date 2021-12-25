using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EurekaCupScript : MonoBehaviour
{
    [Range(-0.5f,0.5f)]
    public float waterLevel;
    public Material waterShader;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waterShader.SetFloat("_waterLevel",waterLevel);
    }
}
