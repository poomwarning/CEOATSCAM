using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateEureka : MonoBehaviour
{
    public NewEurekaCupScript eurekaCupScript;
    public GameObject _object;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            if(other.GetComponent<PlayerCon>().objectOnHead == null && eurekaCupScript.Object != null ){
                eurekaCupScript.TakeObjectOut(other.GetComponent<PlayerCon>());
                return;
            }

            _object = other.GetComponent<PlayerCon>().objectOnHead.gameObject;
            other.GetComponent<PlayerCon>().objectOnHead = null;

            if(eurekaCupScript.Object != null){
                eurekaCupScript.TakeObjectOut(other.GetComponent<PlayerCon>());
            }
            eurekaCupScript.PutObjectIn(_object);

        }
    }

}