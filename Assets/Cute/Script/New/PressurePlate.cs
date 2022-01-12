using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject _object;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            if(other.GetComponent<PlayerCon>().objectOnHead != null){
                other.GetComponent<PlayerCon>().objectOnHead.transform.parent = null;
                other.GetComponent<PlayerCon>().objectOnHead.transform.position = other.GetComponent<PlayerCon>().objectOnHead.pos;
            }
    
            other.GetComponent<PlayerCon>().objectOnHead = _object.GetComponent<NewObjectScript>();
            _object.transform.parent = other.GetComponent<PlayerCon>().headPos;
            _object.transform.position = other.GetComponent<PlayerCon>().headPos.position;
                
            if(other.GetComponent<PlayerCon>().holdBeaker){
                other.GetComponent<PlayerCon>().PutBeakerDown(other.GetComponent<PlayerCon>().beakerScript.pos);
            }        
        }
    }

}
