using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidOnGroundButton : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("NowAnim", animator.name);
            animator.SetBool("Down", !animator.GetBool("Down"));
        }
    }
}
