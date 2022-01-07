using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectScript : MonoBehaviour
{
    public Lab2ScriptableObject Object;
    public Vector3 pos;

    private void Start() {
        pos = this.transform.position;
    }
}
