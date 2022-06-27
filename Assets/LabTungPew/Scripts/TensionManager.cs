using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TensionManager : MonoBehaviour
{
    public LiquidObj[] liquids;
    public LiquidObj liquid;
    [SerializeField]
    private LiquidLoader liquidLoader;
    public NutCollector nutcollector;

    [SerializeField]
    private Animator scalesAnim;

    [SerializeField]
    private GameObject Balanceparticle;


    public GameObject holderObj;

    void Start()
    {

        int Rand = Random.Range(0, liquids.Length - 1);
        liquid = liquids[Rand];
        Debug.Log(liquid.liquidName);
        liquidLoader.liquid = liquid;
        liquidLoader.NormalPew();
        Balanceparticle.SetActive(false);

        //============================ Obsoleote =================================
        //float fMoment = nutcollector.MassSum * Physics.gravity.magnitude * x;
        //float tMoment = liquid.STforce * 2 * RingCircumference * y;
        //Debug.Log($"fMoment : {fMoment}   tMoment : {tMoment}");
        //float CorrectMass = tMoment / (Physics.gravity.magnitude * x);
        //Debug.Log(CorrectMass);
        

    }
    public void CheckState()
    {
        bool result = liquid.STforce == nutcollector.MassSum;
        Debug.Log($"liquid tension : {liquid.STforce} || masssum : {nutcollector.MassSum}");
        switch (result)
        {
            case true:
                BalanceState();
                break;
            case false:
                if (liquid.STforce > nutcollector.MassSum)
                {
                    LowState();
                }
                else
                {
                    HighState();
                }
                break;
        }
    }

    public void BalanceState()
    {
        scalesAnim.SetTrigger("Finish");
        Balanceparticle.SetActive(true);
        liquidLoader.TungPew();
    }
    public void LowState()
    {
        scalesAnim.SetBool("LowState",true);
        scalesAnim.SetBool("HighState", false);
        liquidLoader.NormalPew();
    }
    public void HighState()
    {
        scalesAnim.SetBool("LowState", false);
        scalesAnim.SetBool("HighState", true);
        liquidLoader.NormalPew();
    }
}
