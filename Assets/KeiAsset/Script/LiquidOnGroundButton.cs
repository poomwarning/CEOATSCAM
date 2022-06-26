using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidOnGroundButton : MonoBehaviour
{
    public LiquidObject liquid;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().liquid = liquid;
        }
    }
}
