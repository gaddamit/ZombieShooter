using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private BossButton button1;
    [SerializeField] private BossButton button2;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject button_progress_1;
    [SerializeField] private GameObject button_progress_2;
    [SerializeField] private float shield_button_timer = 15.0f;
    [SerializeField] private float shield_down_duration = 25.0f;
    protected float boss_health = 100;

    private float button1_progress = 0;
    private float button2_progress = 0;
    private bool is_shield_active = true;
    private bool shield_down_coroutine_active = false;
    private float shield_down_timer = 0;

    void Start()
    {
        if (shield != null)
            shield.SetActive(true);
        //shield always starts active
        if (button_progress_1 != null)
        {
            button_progress_1.SetActive(false);
        }
        if (button_progress_2 != null)
        {
            button_progress_2.SetActive(false);
        }
        //these are going to be indicators for when each button's progress is complete
        //for now they'll be a colored gameobject but I want to make them like the OK progress bar on doors
        //...if there's time for me to bother
    }

    private void Update()
    {
        if (boss_health <= 0)
        {
            //play a death coroutine
        }


        if (button_progress_1.activeSelf == true & button_progress_2.activeSelf == true & !shield_down_coroutine_active)
        {
            Debug.Log("both active");
            is_shield_active = false;
            shield.SetActive(false);
            shield_down_coroutine_active = true;
            StartCoroutine(ShieldDeactivated());
        }
        //if both buttons have been activated and the Shield Down coroutine has not been started, boot it up

        if (is_shield_active)
        {
            if (button1_progress < shield_button_timer) //if the button's timer has not been completed...
            {
                if (button1.IsButtonPressed())          //...check if the player is on the button...
                {
                    button1_progress += Time.deltaTime; //... and progress the button's timer if they are.
                }
                else
                {
                    button1_progress -= Time.deltaTime * 0.3f;  //if not, gradually decrease the timer.
                }

            }
            else if (button_progress_1.activeSelf == false)
            {
                button_progress_1.SetActive(true);  //activate the button if the timer is complete
                Debug.Log("button 1 ready");
            }

            if (button2_progress < shield_button_timer)
            {
                if (button2.IsButtonPressed())
                {
                    button2_progress += Time.deltaTime;
                }
                else
                {
                    button2_progress -= Time.deltaTime * 0.3f;
                }
            }
            else if (button_progress_2.activeSelf == false)
            {
                button_progress_2.SetActive(true);
                Debug.Log("button 2 ready");
            }
        }

    }
    private IEnumerator ShieldDeactivated()
    {

        while (shield_down_timer < shield_down_duration)
        {
            shield_down_timer += Time.deltaTime;
            yield return null;
        }
        if (shield != null)
        {
            shield.SetActive(true);
        }
        button1_progress = 0f;
        button2_progress = 0f;
        button_progress_1.SetActive(false);
        button_progress_2.SetActive(false);
        shield_down_timer = 0f;
        is_shield_active = true;
        shield_down_coroutine_active = false;

    }
    public void Hit()
    {
        boss_health = boss_health - 1;
        Debug.Log(boss_health);
    }
}

