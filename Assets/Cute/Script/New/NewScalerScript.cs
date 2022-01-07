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
    public NewObjectScript Object;
    public Lab2ScriptableObject ObjectScriptable;

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

    // private void OnTriggerEnter(Collider other) {
    //     if(other.GetComponent<NewObjectScript>() != null){
    //         other.transform.parent = hangingPos;
    //         other.transform.position = hangingPos.position;

    //         Object = other.GetComponent<NewObjectScript>().Object;
    //         objectText.text = "Weight = " + Object.objectWeight;
    //     } 
    // }

    public void PutObjectIn(GameObject _object){
        moveY = 0;

        _object.transform.parent = hangingPos;
        _object.transform.position = hangingPos.position;

        Object = _object.GetComponent<NewObjectScript>();
        ObjectScriptable = Object.Object;
        objectText.text = "Weight = " + ObjectScriptable.objectWeight + " Kg";
    }

    public void TakeObjectOut(PlayerCon player){
        if(Object != null){
                player.objectOnHead = Object.GetComponent<NewObjectScript>();
                Object.transform.parent = player.GetComponent<PlayerCon>().headPos;
                Object.transform.position = player.GetComponent<PlayerCon>().headPos.position;

                Object = null;
                ObjectScriptable = null;
                objectText.text = "Weight = 0 Kg";
        }
    }

    
}
