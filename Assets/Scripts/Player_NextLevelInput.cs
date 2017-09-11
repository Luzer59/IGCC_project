using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NextLevelInput : MonoBehaviour
{
    public float progress;
    public float timeToFill;

    private float leftTriggerHeldDownTime;
    private float rightTriggerHeldDownTime;
    
    void Update()
    {
        bool left = Input.GetButton("ControllerTriggerLeft");
        bool right = Input.GetButton("ControllerTriggerRight");
        if (left && right)
        {
            progress += Time.deltaTime / timeToFill;
        }
        else
        {
            progress -= Time.deltaTime / (timeToFill * 0.5f);
        }
        if (progress >= 1f)
        {
            print("NextLevelInput triggered");
        }
        progress = Mathf.Clamp(progress, 0f, 1f);
    }
}
