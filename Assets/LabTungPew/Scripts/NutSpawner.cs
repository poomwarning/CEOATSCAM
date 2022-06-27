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
    public OntriggerEnterEvent DropObjectZone;
    public OntriggerEnterEvent Addnut1G;
    public OntriggerEnterEvent Deletenut1G;
    public OntriggerEnterEvent Addnut5G;
    public OntriggerEnterEvent Deletenut5G;
    public OntriggerEnterEvent Addnut10G;
    public OntriggerEnterEvent Deletenut10G;

    private void Start()
    {
        DropObjectZone.onTriggerStay.AddListener(AddDropObjStay);
        DropObjectZone.onTriggerExit.AddListener(RemoveDropObjExit);

        Addnut1G.onTriggerEnter.AddListener(Addnut1GMethod);
        Deletenut1G.onTriggerEnter.AddListener(Deletenut1GMethod);
        Addnut5G.onTriggerEnter.AddListener(Addnut5GMethod);
        Deletenut5G.onTriggerEnter.AddListener(Deletenut5GMethod);
        Addnut10G.onTriggerEnter.AddListener(Addnut10GMethod);
        Deletenut10G.onTriggerEnter.AddListener(Deletenut10GMethod);
    }
    void AddDropObjStay(Collider col)
    {
        if (col.gameObject.tag != "Player") { return; }
        GameObject obj = col.gameObject.GetComponent<CharControl>().PickupObject;
        if (obj)
        {
            obj.GetComponent<PickableObject>().putObjDown = AddObjOnHolder;
            //obj.GetComponent<PickableObject>().pickObjUp += PickObjOnHolder;
        }
        else
        {
            CharControl PlayerCharControl = GameObject.FindObjectOfType<CharControl>();
            if (Input.GetKeyUp(PlayerCharControl.PickUpKey))
            {
                obj = nutcollector.allnut[nutcollector.allnut.Count - 1].gameObject;
                obj.GetComponent<PickableObject>().pickObjUp(obj);
                nutcollector.RemoveNut(obj.GetComponent<Nut>().mass);
            }
        }
        
    }
    void RemoveDropObjExit(Collider col)
    {
        if (col.gameObject.tag != "Player") { return; }
        GameObject obj = col.gameObject.GetComponent<CharControl>().PickupObject;
        if (obj)
        {
            obj.GetComponent<PickableObject>().ResetPutDownFunc();
            obj.GetComponent<PickableObject>().ResetPickUpFunc();
        }
    }
    void AddObjOnHolder(GameObject obj)
    {
        obj.transform.position = NutspawnLocation.transform.position;
        obj.GetComponent<PickableObject>().ResetObj(obj);
        nutcollector.AddNut(obj.GetComponent<Nut>());
    }
    //void PickObjOnHolder(GameObject obj)
    //{
    //    CharControl PlayerCharControl = GameObject.FindObjectOfType<CharControl>();
    //    obj = nutcollector.allnut[nutcollector.allnut.Count - 1].gameObject;
    //    if (Input.GetKeyDown(PlayerCharControl.PickUpKey) && PlayerCharControl.PickupObject == null)
    //    {
    //        obj.GetComponent<PickableObject>().pickObjUp(this.gameObject);
    //    }
    //    nutcollector.RemoveNut(obj.GetComponent<Nut>().mass);
    //    obj.GetComponent<PickableObject>().ResetPickUpFunc();
    //}







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
            nutcollector.RemoveNut(10);
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
            nutcollector.RemoveNut(20);
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
            nutcollector.RemoveNut(30);
        }
    }

}
