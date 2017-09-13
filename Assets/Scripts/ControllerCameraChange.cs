using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCameraChange : MonoBehaviour {

    public Camera MainCamera;
    public Camera SubCamera;


    // Use this for initialization
    void Start()
    {

        MainCamera.enabled = true;
        SubCamera.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        //Change
        if (Input.GetKeyDown("joystick button 4"))
        {
            MainCamera.enabled = !MainCamera.enabled;
            SubCamera.enabled = !SubCamera.enabled;
        }
    }
}
