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
    // Start is called before the first frame update
    void Start()
    {
        hangObject.transform.position = hangPoint.position;
        hangObject.transform.parent = hangPoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveAble.localPosition = new Vector3(0,moveY,0);
    }

    public void HangObejct(ObjectScript objectScript){
        hangObject = objectScript;
        hangObject.transform.position = hangPoint.position;
        hangObject.transform.parent = hangPoint;
    }
}
