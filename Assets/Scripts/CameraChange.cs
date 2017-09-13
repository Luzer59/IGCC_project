using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public Camera MainCamera;
    public Camera SubCamera;
    

	// Use this for initialization
	void Start () {

        MainCamera.enabled = true;
        SubCamera.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

        //Change
		if(Input.GetKeyDown(KeyCode.Space))
        {
            MainCamera.enabled = !MainCamera.enabled;
            SubCamera.enabled = !SubCamera.enabled;
        }
	}
}
