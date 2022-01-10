using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropButton : MonoBehaviour
{
    public Animator animator;
    public string boolname;
    public int WaterHeightDrop = 5;
    public GameObject BaseRightLiquidSpawn;
    public GameObject BaseLeftLiquidSpawn;
    public GameObject NowSpawn;
    public LiquidObject[] Liquid;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            string NowAnim = PlayerPrefs.GetString("NowAnim");
            animator = GameObject.Find(NowAnim).GetComponent<Animator>();
            animator.SetBool(boolname, true);
            Liquid = GameObject.Find(boolname).GetComponentsInChildren<LiquidObject>();
            int samecheck = 0;
            for (int count = 0; count <= Liquid.Length - 1; count++) 
            {
                Debug.Log(Liquid[count].LiquidName);
                if(Liquid[count].LiquidName == GameObject.Find(NowAnim).GetComponent<LiquidObject>().LiquidName)
                {
                    samecheck++;
                    WaterHeightDrop = 10;
                    Liquid[count].Height = WaterHeightDrop;
                }
            }
            if(samecheck == 0)
            {
                if (boolname == "Right")
                {
                    NowSpawn = Instantiate(BaseRightLiquidSpawn, GameObject.Find(boolname).transform);
                    NowSpawn.name = GameObject.Find(NowAnim).GetComponent<LiquidObject>().LiquidName;
                    NowSpawn.SetActive(true);
                    NowSpawn.GetComponent<LiquidObject>().LiquidName = GameObject.Find(NowAnim).GetComponent<LiquidObject>().LiquidName;
                    NowSpawn.GetComponent<LiquidObject>().pho = GameObject.Find(NowAnim).GetComponent<LiquidObject>().pho;
                    NowSpawn.GetComponent<LiquidObject>().Height = WaterHeightDrop;
                }
                if (boolname == "Left")
                {
                    NowSpawn = Instantiate(BaseLeftLiquidSpawn, GameObject.Find(boolname).transform);
                    NowSpawn.name = GameObject.Find(NowAnim).GetComponent<LiquidObject>().LiquidName;
                    NowSpawn.SetActive(true);
                    NowSpawn.GetComponent<LiquidObject>().LiquidName = GameObject.Find(NowAnim).GetComponent<LiquidObject>().LiquidName;
                    NowSpawn.GetComponent<LiquidObject>().pho = GameObject.Find(NowAnim).GetComponent<LiquidObject>().pho;
                    NowSpawn.GetComponent<LiquidObject>().Height = WaterHeightDrop;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool(boolname, false);
        }
    }
}
