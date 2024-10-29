using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_press : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("inactive");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play("activated");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play("inactive");
            Debug.Log("exit");
        }
    }
}
