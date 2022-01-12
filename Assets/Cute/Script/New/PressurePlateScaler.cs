using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScaler : MonoBehaviour
{
    public NewScalerScript scalerScript;
    public GameObject _object;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            if(other.GetComponent<PlayerCon>().objectOnHead == null && scalerScript.Object != null ){
                scalerScript.TakeObjectOut(other.GetComponent<PlayerCon>());
                if(other.GetComponent<PlayerCon>().holdBeaker){
                    other.GetComponent<PlayerCon>().PutBeakerDown(other.GetComponent<PlayerCon>().beakerScript.pos);
                }  
                return;
            }

            _object = other.GetComponent<PlayerCon>().objectOnHead.gameObject;
            other.GetComponent<PlayerCon>().objectOnHead = null;

            if(scalerScript.Object != null){
                scalerScript.TakeObjectOut(other.GetComponent<PlayerCon>());
            }
            scalerScript.PutObjectIn(_object);

            if(other.GetComponent<PlayerCon>().holdBeaker){
                other.GetComponent<PlayerCon>().PutBeakerDown(other.GetComponent<PlayerCon>().beakerScript.pos);
            }  
        }
    }

}