using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{
    public GameObject Nut1g;
    public GameObject Nut10g;
    public GameObject Nut100g;
    public GameObject NutspawnLocation;
    public NutCollector nutcollector;
    // Start is called before the first frame update
    public OntriggerEnterEvent Addnut1G;
    public OntriggerEnterEvent Deletenut1G;
    public OntriggerEnterEvent Addnut5G;
    public OntriggerEnterEvent Deletenut5G;
    public OntriggerEnterEvent Addnut10G;
    public OntriggerEnterEvent Deletenut10G;

    private void Start()
    {
        Addnut1G.onTriggerEnter.AddListener(Addnut1GMethod);
        Deletenut1G.onTriggerEnter.AddListener(Deletenut1GMethod);
        Addnut5G.onTriggerEnter.AddListener(Addnut5GMethod);
        Deletenut5G.onTriggerEnter.AddListener(Deletenut5GMethod);
        Addnut10G.onTriggerEnter.AddListener(Addnut10GMethod);
        Deletenut10G.onTriggerEnter.AddListener(Deletenut10GMethod);
    }
    void Addnut1GMethod(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject nut1g = Instantiate(Nut1g, NutspawnLocation.transform.position, Quaternion.identity);
            nutcollector.AddNut(nut1g.GetComponent<Nut>());
        }
    }
    void Deletenut1GMethod(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            nutcollector.RemoveNut(0.001f);
        }
    }
    void Addnut5GMethod(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject nut5g = Instantiate(Nut10g, NutspawnLocation.transform.position, Quaternion.identity);
            nutcollector.AddNut(nut5g.GetComponent<Nut>());
        }
    }
    void Deletenut5GMethod(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            nutcollector.RemoveNut(0.01f);
        }
    }
    void Addnut10GMethod(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject nut10g = Instantiate(Nut100g, NutspawnLocation.transform.position, Quaternion.identity);
            nutcollector.AddNut(nut10g.GetComponent<Nut>());
        }
    }
    void Deletenut10GMethod(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            nutcollector.RemoveNut(0.1f);
        }
    }

}
