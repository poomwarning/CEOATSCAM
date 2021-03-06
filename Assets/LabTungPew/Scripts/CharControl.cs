using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public float Speed;

    public KeyCode PickUpKey;
    public KeyCode PutDownKey;
    public Transform HeadPos;
    public GameObject PickupObject = null;
    private Vector3 movement;
    [SerializeField]
    private Rigidbody playerRigid;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal*-1, 0f, moveVertical * -1);

        playerRigid.velocity = movement * Speed * Time.deltaTime;
        PutDownObj();
        
    }
    public void PutDownObj()
    {
        if (Input.GetKeyUp(PutDownKey) && PickupObject != null)
        {
            PickupObject.GetComponent<PickableObject>().putObjDown(PickupObject);
        }
    }
   
}
