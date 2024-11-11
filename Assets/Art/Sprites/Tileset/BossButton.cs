using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButton : MonoBehaviour
{

    private Animator animator;
    private bool button_pressed = false;

    public bool IsButtonPressed()
    {
        return button_pressed;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("inactive");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            button_pressed = true;
            animator.Play("activated");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            button_pressed = false;
            animator.Play("inactive");
            Debug.Log("exit");
        }
    }
}
