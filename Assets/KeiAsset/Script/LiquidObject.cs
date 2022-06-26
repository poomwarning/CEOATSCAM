using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidObject : MonoBehaviour
{
    [Header("Height in cm Unit")]
    public float Height;
    public float defualtHeightForWater = 100;
    public float moveDown;
    public float moveUp;
    [Header("This Object Is Drop Water)")]
    public bool IsDropWater;
    [Header("Pressure in pascal Unit")]
    public float Pressure;

    // Update is called once per frame
    void Update()
    {
        if (IsDropWater)
            return;

        if (transform.localScale.y < ((Height / 100) + 0.01f))
            transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime;
        else if(transform.localScale.y > ((Height / 100) + 0.01f) && transform.localScale.y > 0.01f)
            transform.localScale -= new Vector3(0, 1, 0) * Time.deltaTime;
    }
}
