using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_NextLevelInput : MonoBehaviour
{
    public float progress;
    public float timeToFill;
    public bool active;
    public LevelChanger levelChanger;

    private float leftTriggerHeldDownTime;
    private float rightTriggerHeldDownTime;

    [SerializeField]
    private string sceneName;
    
    public void SetActive(bool state)
    {
        active = state;
    }

    void Update()
    {
        if (active)
        {
            bool left = Input.GetButton("ControllerTriggerLeft");
            bool right = Input.GetButton("ControllerTriggerRight");
            bool newOverrideButton = Input.GetButton("NextLevelInputOverride");
            if (newOverrideButton)
            {
                progress += Time.deltaTime / timeToFill;
            }
            else
            {
                progress -= Time.deltaTime / (timeToFill * 0.5f);
            }
            if (progress >= 1f)
            {
                LevelChanger.instance.ChangeLevel(sceneName);
            }
            progress = Mathf.Clamp(progress, 0f, 1f);
        }
    }
}
