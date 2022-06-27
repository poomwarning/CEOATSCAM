using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public CharControl PlayerCharControl;
    [SerializeField]
    private Rigidbody ObjRB;
    public Vector3 PutDownDirect;
    public bool IsPick;
    public delegate void PutDownfunc(GameObject obj);
    public delegate void Pickupfunc(GameObject obj);
    public PutDownfunc putObjDown;
    public Pickupfunc pickObjUp;
    void Start()
    {
        IsPick = false;
        PlayerCharControl = GameObject.FindObjectOfType<CharControl>();
        ObjRB = this.GetComponent<Rigidbody>();
        putObjDown = NormalPutDown;
        pickObjUp = NormalPickUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPick)
        {
            this.transform.position = PlayerCharControl.HeadPos.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        if (Input.GetKeyDown(PlayerCharControl.PickUpKey) && PlayerCharControl.PickupObject == null)
        {
            pickObjUp(this.gameObject);
        }

    }
    public void NormalPickUp(GameObject obj)
    {
        IsPick = true;
        obj.transform.position = PlayerCharControl.HeadPos.position;
        obj.transform.parent = PlayerCharControl.HeadPos;
        ObjRB.useGravity = false;
        PlayerCharControl.PickupObject = obj;
    }
    public void NormalPutDown(GameObject obj)
    {
        PutDownDirect = obj.transform.forward;
        obj.transform.position = PlayerCharControl.gameObject.transform.position
            + new Vector3(PutDownDirect.x,0,PutDownDirect.z);
        ResetObj(obj);
    }
    public void ResetObj(GameObject obj)
    {
        PlayerCharControl.PickupObject = null;
        obj.transform.parent = null;
        ObjRB.useGravity = true;
        IsPick = false;
    }
    public void ResetPutDownFunc()
    {
        putObjDown = NormalPutDown;
    }
    public void ResetPickUpFunc()
    {
        pickObjUp = NormalPickUp;
    }
}
