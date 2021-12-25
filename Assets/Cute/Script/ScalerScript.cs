using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerScript : MonoBehaviour
{
    [Range(-1f,0f)]
    public float moveY;
    public Transform moveAble;
    public Transform hangPoint;

    public ObjectScript hangObject;
    public float mass;
    // Start is called before the first frame update
    void Start()
    {
        hangObject.transform.position = hangPoint.position;
        hangObject.transform.parent = hangPoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveAble.position = new Vector3(0,moveY,0);
    }

    public void HangObejct(ObjectScript objectScript){
        hangObject = objectScript;
        mass = hangObject.mass;
        hangObject.transform.position = hangPoint.position;
        hangObject.transform.parent = hangPoint;
    }
}
