using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensionManager : MonoBehaviour
{
    public LiquidObj[] liquids;
    [SerializeField]
    private LiquidObj liquid;
  public Nut nut = null;
    [SerializeField]
    private float RingCircumference;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private GameObject Balanceparticle;
    void Start()
    {
        int Rand = Random.Range(0, liquids.Length - 1);
        liquid = liquids[Rand];
        Debug.Log(liquid.liquidName);
        float fMoment = nut.mass * Physics.gravity.magnitude * x;
        float tMoment = liquid.STforce * 2 * RingCircumference * y;
        Debug.Log($"fMoment : {fMoment}   tMoment : {tMoment}");
        float CorrectMass = tMoment / (Physics.gravity.magnitude * x);
        Debug.Log(CorrectMass);
    }

    // Update is called once per frame
    void Update()
    {
        if (TensionEquaion())
        {
            BalanceState();
        }
        else
        {
            Balanceparticle.SetActive(false);
        }
    }
    public bool TensionEquaion()
    {
        float fMoment = nut.mass * Physics.gravity.magnitude * x;
        float tMoment = liquid.STforce * 2 * RingCircumference*y;
        Debug.Log(Mathf.Abs(fMoment / tMoment));
        if (Mathf.Abs(fMoment / tMoment) >= 0.75)
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
    }
}
