using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EurekaCupScript : MonoBehaviour
{
    [Range(-0.5f,0.5f)]
    public float waterLevel;
    public Material waterShader;
    public LiquidScript liquidScript;
    
    public ObjectScript hangingObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        liquidScript = GetComponent<LiquidScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waterShader.SetFloat("_waterLevel",waterLevel);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<ObjectScript>() != null){
            hangingObject = other.GetComponent<ObjectScript>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<ObjectScript>() != null){
            hangingObject = null;
        }
    }

}
