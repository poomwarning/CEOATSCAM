using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EurekaCupScript : MonoBehaviour
{
    public float percentOfDrowning = 0;
    public float buoyantforce = 0;
    public float overflowWater = 0;
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
            CalculateBuoyantforce();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<ObjectScript>() != null){
            hangingObject = null;
        }
    }

    void CalculateBuoyantforce(){
        //Fb = rho liquid * V object * g(9.8f)

        //rho liquid <= rho Object
        if(liquidScript.rho <= hangingObject.rho){
            buoyantforce = hangingObject.mass * 9.8f;
            overflowWater = buoyantforce / 9.8f;
        }

        //rho liquid > rho Object
        if(liquidScript.rho > hangingObject.rho){
            percentOfDrowning = hangingObject.rho/liquidScript.rho;
            buoyantforce = hangingObject.mass * percentOfDrowning * 9.8f;
            overflowWater = buoyantforce / 9.8f;
        }
    }

}
