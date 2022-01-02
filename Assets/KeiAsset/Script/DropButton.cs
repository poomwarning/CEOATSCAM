using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropButton : MonoBehaviour
{
    public Animator animator;
    public string boolname;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator = GameObject.Find(PlayerPrefs.GetString("NowAnim")).GetComponent<Animator>();
            animator.SetBool(boolname, true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool(boolname, false);
        }
    }
}
