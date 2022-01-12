using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownBeaker : MonoBehaviour
{
    public BeakerScript beakerScript;
    public Transform beakerPosition;
    PlayerCon player;
    NewEurekaCupScript eurekaCupScript;

    void Start()
    {
        player = FindObjectOfType<PlayerCon>().GetComponent<PlayerCon>();
        eurekaCupScript = FindObjectOfType<NewEurekaCupScript>().GetComponent<NewEurekaCupScript>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            //Set position beaker
            other.GetComponent<PlayerCon>().PutBeakerDown(beakerPosition.position);

            //show water weight
            print("Show");
            eurekaCupScript.overflowWaterText.text = "Overflow Liquid Weight = " + eurekaCupScript.ObjectScriptable.overflowLiquidWeight + " Kg";
        }
    }
}
