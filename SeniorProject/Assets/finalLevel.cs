﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalLevel : MonoBehaviour
{
    int grabTimes = 0;
    public OVRGrabbable grabbedObject;
    public GameObject hiddenToolTip;
    public GameObject newToolTip;
    public GeneratorButton2 lab2;
    public GeneratorButton3 lab3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbedObject.isGrabbed == true)
        {
            if(grabTimes == 0)
            {
                lab2.reset();
                lab3.reset();
                // Play an audio source
                hiddenToolTip.SetActive(false);
                newToolTip.SetActive(true);
                grabTimes = 1;
            }
        }
    }
}
