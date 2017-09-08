using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(StandaloneInputModule))]
public class EventSystemInputController : MonoBehaviour
{
    [System.Serializable]
    public struct Settings
    {
        public string horizontalAxis;
        public string verticalAxis;
        public string submitButton;
        public string cancelButton;
    }

    public Settings keyboard;
    public Settings controller;

    private StandaloneInputModule inputSystem;

    void Awake()
    {
        inputSystem = GetComponent<StandaloneInputModule>();
    }

    void Start()
    {
        if (Input.GetJoystickNames().Length == 0)
        {
            inputSystem.horizontalAxis = keyboard.horizontalAxis;
            inputSystem.verticalAxis = keyboard.verticalAxis;
            inputSystem.submitButton = keyboard.submitButton;
            inputSystem.cancelButton = keyboard.cancelButton;
        }
        else
        {
            inputSystem.horizontalAxis = controller.horizontalAxis;
            inputSystem.verticalAxis = controller.verticalAxis;
            inputSystem.submitButton = controller.submitButton;
            inputSystem.cancelButton = controller.cancelButton;
        }
    }
}
