using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private CharControl PlayerCharControl;
    [SerializeField]
    private Rigidbody ObjRB;
    public Vector3 PutDownDirect;
    public bool IsPick;
    void Start()
    {
        IsPick = false;
        PlayerCharControl = GameObject.FindObjectOfType<CharControl>();
        ObjRB = this.GetComponent<Rigidbody>();
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
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(PlayerCharControl.PickUpKey) && PlayerCharControl.PickupObject == null)
            {
                IsPick = true;
                this.transform.position = PlayerCharControl.HeadPos.position;
                this.transform.parent = PlayerCharControl.HeadPos;
                ObjRB.useGravity = false;
                PlayerCharControl.PickupObject = this.gameObject;
                PutDownDirect = (this.transform.position - other.gameObject.transform.position );
                Debug.Log(PutDownDirect);
            }
        }
    }
    public void PutDownfunc()
    {
        this.transform.position = PlayerCharControl.gameObject.transform.position
            + new Vector3(PutDownDirect.x,0,PutDownDirect.z);
        PlayerCharControl.PickupObject = null;
        this.transform.parent = null;
        ObjRB.useGravity = true;
        IsPick = false;
    }
}
