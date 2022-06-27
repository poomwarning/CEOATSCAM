using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCollector : MonoBehaviour
{
    public float MassSum;
    public List<Nut> allnut;
    public TensionManager t_Manager;
    void Start()
    {
        MassSum = 0;
        allnut = new List<Nut>();
        t_Manager = GameObject.Find("TensionManager").GetComponent<TensionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNut(Nut nut)
    {
        allnut.Add(nut);
        MassSum += nut.mass;
        t_Manager.CheckState();
    }
    public void RemoveNut(float mass)
    {
        for(int i=0;i<= allnut.Count-1;i++)
        {
            if(allnut[i].mass == mass)
            {
                MassSum -= mass;
                //Destroy(allnut[i].gameObject);
                allnut.RemoveAt(i);
                allnut.RemoveAll(item => item == null);
                Debug.Log(i);
                t_Manager.CheckState();
                return;
            }
        }
    }
}
