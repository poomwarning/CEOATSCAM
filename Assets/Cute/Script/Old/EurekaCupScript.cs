using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EurekaCupScript : MonoBehaviour
{
    public float percentOfDrowning = 0;
    public float buoyantforce_N = 0;
    public float overflowWater_Kg = 0;
    public float hangingObjectOnLiquid_N = 0;
    public float hangingObjectOnLiquid_Kg = 0;
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
        // if(liquidScript.rho <= hangingObject.rho){
        //     buoyantforce = liquidScript.rho * hangingObject.volume * 9.8f;
        //     overflowWater = buoyantforce / 9.8f;
        // }

        //rho liquid > rho Object
        // if(liquidScript.rho > hangingObject.rho){
            percentOfDrowning = hangingObject.rho/liquidScript.rho;
            print(hangingObject.volume * percentOfDrowning);
            print(hangingObject.volume - (hangingObject.volume * percentOfDrowning));
            buoyantforce_N = liquidScript.rho * (hangingObject.volume * percentOfDrowning) * 9.8f;
            overflowWater_Kg = buoyantforce_N /9.8f;
            hangingObjectOnLiquid_N = (hangingObject.mass * 9.8f) - buoyantforce_N;
            hangingObjectOnLiquid_Kg = hangingObjectOnLiquid_N / 9.8f;
        // }
    }

}
