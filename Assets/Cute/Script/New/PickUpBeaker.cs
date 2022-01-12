using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBeaker : MonoBehaviour
{
    public BeakerScript beakerScript;
    public Transform beakerPosition;
    PlayerCon player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCon>().GetComponent<PlayerCon>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            //Set position beaker
            other.GetComponent<PlayerCon>().PickUpBeaker();

        }
    }
}
