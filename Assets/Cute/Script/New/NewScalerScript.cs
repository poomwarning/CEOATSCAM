using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScalerScript : MonoBehaviour
{
    [Header("Scaler")]
    [Range(-1f,0f)]
    public float moveY;
    public Transform moveAble;
    public Transform hangingPos;
    [Header("Text")]
    public Text objectText;

    [Header("ScriptableObject")]
    public Lab2ScriptableObject Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hanging();
        moveAble.localPosition = new Vector3(0,moveY,0);
    }

    void Hanging(){
        if(Object != null){
            if(moveY > -1){
                moveY -= Time.deltaTime * 2;
            }
        }if(Object == null){
            if(moveY < 0){
                moveY += Time.deltaTime * 2;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<NewObjectScript>() != null){
            other.transform.parent = hangingPos;
            other.transform.position = hangingPos.position;

            Object = other.GetComponent<NewObjectScript>().Object;
            objectText.text = "Mass = " + Object.objectMass;
        } 
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<NewObjectScript>() != null){
            other.transform.parent = null;
            other.transform.position = Vector3.zero;

            Object = null;
            objectText.text = "Mass = 0";
        }
    }
}
