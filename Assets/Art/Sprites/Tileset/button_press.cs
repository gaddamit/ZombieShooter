using System;
using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

public class button_press : MonoBehaviour
{
    private Animator animator;
    private PlayMakerFSM CapturepointFSM;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("inactive");
        CapturepointFSM = GetComponent<PlayMakerFSM>();
    }

    private void Update()
    {
        CheckCapturepointTimer();
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

    private void CheckCapturepointTimer()
    {
        FsmFloat timer = CapturepointFSM.FsmVariables.GetFsmFloat("CaptureTimer");
        
        if (timer.Value <= 0)
        {
            animator.Play("activated");
            animator.speed = 0;
            animator.Play("activated", 0, 0);
        }
    }
}
