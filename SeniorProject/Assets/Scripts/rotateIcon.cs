﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rotateIcon : MonoBehaviour
{

    public Image icon;

    float speed = 1.0f;

    public Transform canvas;

    Animator animator;

    public Image informationBackground;

    public Text infoText;

    public Text meters;

    public ARStayActive arStay;

    private bool iscalled;

    public GameObject parent;

    public ArmMenu ArmMenu; 


    // Start is called before the first frame update
    void Start()
    {
        animator = canvas.GetComponent<Animator>();

        informationBackground.enabled = false;
        infoText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (arStay.playerTrigger)
        {
            if (ArmMenu.SonarWaveOn == true)
            {
                print("Collision, can spin icon");
                animator.SetTrigger("Spin");
                animator.ResetTrigger("Reverse");
            }
        }

        else
        {
            if (ArmMenu.SonarWaveOn == true)
            {
                print(gameObject.name + " and trigger object " + "" + " are no longer colliding");
                animator.SetTrigger("Reverse");
                animator.ResetTrigger("Spin");
            }       
        }
    }

    void swapIcon()
    {
        print("Change Icons");

        icon.enabled = false;
        meters.enabled = false;



        informationBackground.enabled = true;
        infoText.enabled = true;
    }

    void walkOut()
    {
        print("Change Back");

        icon.enabled = true;
        meters.enabled = true;



        informationBackground.enabled = false;
        infoText.enabled = false;
    }

    void hide()
    {
        parent.transform.GetChild(0).gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }
}
