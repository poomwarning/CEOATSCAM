using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViscosityArea : MonoBehaviour
{
    public float speed;
    public float garvity;
    public float constGarvity;
    public float currentGarvity;
    public float maxGarvity;
    Vector3 garvityMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("obj"))
        {
            Attract(other.GetComponent<ViscosityObject>());
        }
    }

    void Attract(ViscosityObject obj)
    {
        Rigidbody rbObj = obj.rb;

        Vector3 direction = Vector3.down;
        
        obj.rb.velocity = calculateGarvity() * obj.mass * Time.deltaTime;
    }

    Vector3 calculateGarvity()
    {
        currentGarvity += speed * Time.deltaTime;
        if(currentGarvity > maxGarvity)
        {
            currentGarvity -= garvity * Time.deltaTime;
        }

        garvityMovement = Vector3.down * currentGarvity;
        return garvityMovement;
    }
}
