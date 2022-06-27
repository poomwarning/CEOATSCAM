using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OntriggerEnterEvent : MonoBehaviour
{
    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerStay;
    public UnityEvent<Collider> onTriggerExit;

    void OnTriggerEnter(Collider col)
    {
        if (onTriggerEnter != null) onTriggerEnter.Invoke(col);
    }
    private void OnTriggerStay(Collider col)
    {
        if (onTriggerStay != null) onTriggerStay.Invoke(col);
    }
    private void OnTriggerExit(Collider col)
    {
        if (onTriggerExit != null) onTriggerExit.Invoke(col);
    }
}
