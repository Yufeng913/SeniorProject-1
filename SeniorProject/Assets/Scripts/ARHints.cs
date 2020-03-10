﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARHints : MonoBehaviour
{
    // Update is called once per frame
    //public Shader interactableShader;
    //Shader defaultShader;
    Material objectMaterial;
    public Material highlightMat;
    //Material defaultObjMat;
    GameObject selectedObject;
    public GameObject toolTip;
    public GameObject toolTipText;
    public Camera centerCam;
    //ToolTip toolTipText;
    void Update()
    {
        RaycastFromOculus();
    }

    void RaycastFromOculus()
    {

        float rayLength = 5.0f;

        Vector3 oculusPos = transform.position;
        Vector3 rayDirection = transform.forward;
        //Debug.Log(transform.forward);
        Ray rayscastRay = new Ray(oculusPos, rayDirection);
        RaycastHit raycastHit;

        Vector3 rayEndPos = oculusPos + rayDirection * rayLength;

        bool objectHit = Physics.Raycast(rayscastRay, out raycastHit, rayLength);

        if (objectHit)
        {
            GameObject hitObject = raycastHit.transform.gameObject;
            string hitObjectName = hitObject.name;

            if (hitObject.tag == "ToolTip")
            {
                if (hitObject != selectedObject)
                {

                    objectMaterial = hitObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                    int children = hitObject.transform.childCount;
                    List<GameObject> subObjectHighlights = null;
                    for (int i = 0; i < children; ++i)
                    {
                        hitObject.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = highlightMat;
                        //subObjectHighlights.Add(hitObject.transform.GetChild(i).gameObject);
                    }

                    //hitObject.GetComponent<Renderer>().material = highlightMat;
                    toolTip.SetActive(true);
                    toolTip.transform.position = hitObject.transform.position;

                    selectedObject = hitObject;
                    Debug.Log("Object " + selectedObject.name + " was hit.");
                }

                toolTip.transform.LookAt(toolTip.transform.position + centerCam.transform.rotation * Vector3.back);
                toolTipText.GetComponent<Text>().text = hitObject.GetComponent<ToolTip>().toolTipText;
            }
        }
        else
        {
            if (selectedObject != null)
            {
                //Debug.Log("No Object being hit");
                int children = selectedObject.transform.childCount;
                for (int i = 0; i < children; ++i)
                {
                    selectedObject.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = objectMaterial;
                }
                //selectedObject.GetComponent<Renderer>().material = objectMaterial;
                selectedObject = null;
                toolTip.SetActive(false);

            }
        }

        Debug.DrawLine(oculusPos, rayEndPos);

    }
}