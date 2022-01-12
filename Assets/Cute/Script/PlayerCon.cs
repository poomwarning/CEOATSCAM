using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    float speed = 5f;
    public NewObjectScript objectOnHead;
    public BeakerScript beakerScript;
    public bool holdBeaker = false;
    public Transform headPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
    }

    public void PickUpBeaker(){
        if(objectOnHead != null){
            objectOnHead.transform.position = objectOnHead.pos;
            objectOnHead.transform.parent = null;
            objectOnHead = null;
        }

        beakerScript.transform.parent = headPos;
        beakerScript.transform.localPosition = Vector3.zero;
        holdBeaker = true;
    }

    public void PutBeakerDown(Vector3 pos){
        beakerScript.transform.parent = null;
        beakerScript.transform.localPosition = pos;
        holdBeaker = false;
    }
}
