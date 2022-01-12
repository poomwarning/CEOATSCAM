using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEurekaCupScript : MonoBehaviour
{
    [Header("Scaler")]
    [Range(-0.1f,0f)]
    public float moveY;
    public Transform moveAble;
    public Transform hangingPos;

    [Header("Overflow Water")]
    public Transform beakerPosition;
    public BeakerScript beakerScript;

    [Header("Text")]
    public Text objectText;
    public Text buoyantforceText;
    public Text overflowWaterText;

    [Header("ScriptableObject")]
    public NewObjectScript Object;
    public Lab2ScriptableObject ObjectScriptable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hanging();
        Overflow();

        // overflowWaterText.text = "Overflow Liquid Weight = " + beakerScript.overflowLiquidWeight + " Kg";
    }

    void Hanging(){
        moveAble.localPosition = new Vector3(0,moveY,0);

        if(Object != null){
            if(moveY > -0.1){
                moveY -= Time.deltaTime * 0.2f;
            }
        }if(Object == null){
            if(moveY < 0){
                moveY += Time.deltaTime * 0.2f;
            }
        }
    }

    void Overflow(){
        if(Object != null){
            if(beakerScript.waterLevel < 0){
                beakerScript.waterLevel += Time.deltaTime * 0.5f;
            }
        }if(Object == null){
            if(beakerScript.waterLevel > -0.5f){
                beakerScript.waterLevel -= Time.deltaTime * 0.5f;
            }
        }
    }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.GetComponent<NewObjectScript>() != null){
    //         other.transform.parent = hangingPos;
    //         other.transform.position = hangingPos.position;

    //         Object = other.GetComponent<NewObjectScript>().Object;
    //         objectText.text = "Weight = " + Object.objectWeight;
    //         buoyantforceText.text = "Buoyantforce = " + Object.Buoyantforce;
    //         overflowWaterText.text = "Overflow Liquid Weight = " + Object.overflowLiquidWeight;

    //     } 
    // }

    // private void OnTriggerExit(Collider other) {
    //     if(other.GetComponent<NewObjectScript>() != null){
    //         other.transform.parent = null;
    //         other.transform.position = Vector3.zero;

    //         Object = null;
    //         objectText.text = "Weight = 0";
    //         buoyantforceText.text = "Buoyantforce = " + 0;
    //         overflowWaterText.text = "Overflow Liquid Weight = " + 0;
    //     }
    // }

    public void PutObjectIn(GameObject _object){
        //Set position beaker
        beakerScript.transform.parent = beakerPosition;
        beakerScript.transform.localPosition = Vector3.zero;

        moveY = 0;
        beakerScript.waterLevel = -.5f;

        _object.transform.parent = hangingPos;
        _object.transform.position = hangingPos.position;

        Object = _object.GetComponent<NewObjectScript>();
        ObjectScriptable = Object.Object;
        objectText.text = "Weight = " + ObjectScriptable.drowingObjectWeight + " Kg";
        buoyantforceText.text = "Buoyantforce = " + ObjectScriptable.Buoyantforce + " N";
        // overflowWaterText.text = "Overflow Liquid Weight = " + ObjectScriptable.overflowLiquidWeight + " Kg";
        beakerScript.overflowLiquidWeight = ObjectScriptable.overflowLiquidWeight;

        
    }

    public void TakeObjectOut(PlayerCon player){
        if(Object != null){
                player.objectOnHead = Object.GetComponent<NewObjectScript>();
                Object.transform.parent = player.GetComponent<PlayerCon>().headPos;
                Object.transform.position = player.GetComponent<PlayerCon>().headPos.position;

                Object = null;
                ObjectScriptable = null;
                objectText.text = "Weight = 0 Kg";
                buoyantforceText.text = "Buoyantforce = 0 N";
                // overflowWaterText.text = "Overflow Liquid Weight = 0 Kg";
        }
    }

    
}
