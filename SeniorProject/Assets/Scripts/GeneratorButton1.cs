﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorButton1 : MonoBehaviour
{
    public bool active = false;
    public Animator animController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand" && !active)
        {
            active = true;
            animController.SetBool("Play", true);
        }
    }


    public void reset()
    {
        active = false;
        Debug.Log(this.gameObject.name + "Button With Error");
        animController.SetBool("Play", false);
    }

}