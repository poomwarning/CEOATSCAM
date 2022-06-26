using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropButton : MonoBehaviour
{
    public string boolname;
    public GameObject BaseRightLiquidSpawn;
    public GameObject BaseLeftLiquidSpawn;
    public LiquidObject waterRight;
    public LiquidObject waterLeft;
    public Transform leftTube;
    public Transform rightTube;
    public LiquidObject liquid;
    public GameObject cloneLiquid;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(liquid != null)
                liquid = null;

            liquid = FindObjectOfType<CharacterController>().GetComponent<CharacterController>().liquid;
            
            if (boolname == "Right")
                {
                    cloneLiquid = Instantiate(BaseRightLiquidSpawn,rightTube);
                    cloneLiquid.SetActive(true);
                    cloneLiquid.GetComponent<LiquidObject>().Height = liquid.Height;
                    waterRight.Height -= liquid.moveDown;
                    waterLeft.Height += liquid.moveUp;
                }
            if (boolname == "Left")
            {
                cloneLiquid = Instantiate(BaseLeftLiquidSpawn,leftTube);
                cloneLiquid.SetActive(true);
                cloneLiquid.GetComponent<LiquidObject>().Height = liquid.Height;
                waterLeft.Height -= liquid.moveDown;
                waterRight.Height += liquid.moveUp;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(cloneLiquid);
            waterLeft.Height = waterLeft.defualtHeightForWater;
            waterRight.Height = waterRight.defualtHeightForWater;
        }
    }
}
