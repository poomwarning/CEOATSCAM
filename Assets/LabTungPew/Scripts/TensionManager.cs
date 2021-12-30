using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensionManager : MonoBehaviour
{
    public LiquidObj[] liquids;
    [SerializeField]
    private LiquidObj liquid;
    [SerializeField]
    private LiquidLoader liquidLoader;
    public NutCollector nutcollector;
    [SerializeField]
    private float RingCircumference;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;

    [SerializeField]
    private GameObject Balanceparticle;
    [SerializeField]
    private Rigidbody ringWeight;
    [SerializeField]
    private bool BChecked;
    [SerializeField]
    private bool UBChecked;
    void Start()
    {
        BChecked = false;
        UBChecked = true;
        int Rand = Random.Range(0, liquids.Length - 1);
        liquid = liquids[Rand];
        Debug.Log(liquid.liquidName);
        liquidLoader.liquid = liquid;
        liquidLoader.NormalPew();
        Balanceparticle.SetActive(false);
        float fMoment = nutcollector.MassSum * Physics.gravity.magnitude * x;
        float tMoment = liquid.STforce * 2 * RingCircumference * y;
        Debug.Log($"fMoment : {fMoment}   tMoment : {tMoment}");
        float CorrectMass = tMoment / (Physics.gravity.magnitude * x);
        Debug.Log(CorrectMass);
        //ringWeight.mass = CorrectMass + 0.9f ;

    }

    // Update is called once per frame
    void Update()
    {
        if (TensionEquaion() )
        {
            UBChecked = false;
            if (!BChecked)
            {
                Debug.Log("Balance");
                Balanceparticle.SetActive(true);
                liquidLoader.TungPew();
                BChecked = true;
            }
        }
        else 
        {
            BChecked = false;
            if (!UBChecked)
            {
                Debug.Log("UnBalance");
                Balanceparticle.SetActive(false);
                liquidLoader.NormalPew();
                UBChecked = true;
            }
        }
    }
    public bool TensionEquaion()
    {
        float fMoment = nutcollector.MassSum * Physics.gravity.magnitude * x;
        float tMoment = liquid.STforce * 2 * RingCircumference*y;
        Debug.Log(Mathf.Abs(fMoment / tMoment));
        if (Mathf.Abs(fMoment / tMoment) >= 0.85 && Mathf.Abs(fMoment / tMoment) <= 1)
        {
            Debug.Log($"fMoment : {fMoment}   tMoment : {tMoment}");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BalanceState()
    {
        Balanceparticle.SetActive(true);
        liquidLoader.TungPew();
    }
}
