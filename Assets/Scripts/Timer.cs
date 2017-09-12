using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time;
    public bool timerflag = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timerflag)
        {
            if (time > 1)
            {
                time -= Time.deltaTime;
            }
        }

        this.GetComponent<Text>().text = "Time : " + Mathf.Floor(time);
	}
}
