using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    // Start is called before the first frame update
    public float Mass;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = Mass;
    }
    private void Start()
    {
    }
    public float mass
    {
        get { return Mass; }
    }
}
