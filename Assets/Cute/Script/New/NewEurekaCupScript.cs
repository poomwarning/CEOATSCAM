using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEurekaCupScript : MonoBehaviour
{
    [Header("Scaler")]
    [Range(-1f,0f)]
    public float moveY;
    public Transform moveAble;
    public Transform hangingPos;

    [Header("Overflow Water")]
    [Range(-0.5f,0f)]
    public float waterLevel;
    public Material waterShader;

    [Header("Text")]
    public Text objectText;
    public Text buoyantforceText;
    public Text overflowWaterText;

    [Header("ScriptableObject")]
    public Lab2ScriptableObject Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hanging();
        Overflow();
    }

    void Hanging(){
        moveAble.localPosition = new Vector3(0,moveY,0);

        if(Object != null){
            if(moveY > -1){
                moveY -= Time.deltaTime * 2;
            }
        }if(Object == null){
            if(moveY < 0){
                moveY += Time.deltaTime * 2;
            }
        }
    }

    void Overflow(){
        waterShader.SetFloat("_waterLevel",waterLevel);

        if(Object != null){
            if(waterLevel < 0){
                waterLevel += Time.deltaTime;
            }
        }if(Object == null){
            if(waterLevel > -0.5f){
                waterLevel -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<NewObjectScript>() != null){
            other.transform.parent = hangingPos;
            other.transform.position = hangingPos.position;

            Object = other.GetComponent<NewObjectScript>().Object;
            objectText.text = "Mass = " + Object.objectMass;
            buoyantforceText.text = "Buoyantforce = " + Object.Buoyantforce;
            overflowWaterText.text = "Overflow Liquid Mass = " + Object.overflowLiquidMass;

        } 
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<NewObjectScript>() != null){
            other.transform.parent = null;
            other.transform.position = Vector3.zero;

            Object = null;
            objectText.text = "Mass = 0";
            buoyantforceText.text = "Buoyantforce = " + 0;
            overflowWaterText.text = "Overflow Liquid Mass = " + 0;
        }
    }
}
