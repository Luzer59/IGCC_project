using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage2Judge : MonoBehaviour {

    [SerializeField]
    private GameObject timerText;

    [SerializeField]
    private GameObject roundText;

    [SerializeField]
    private GameObject playerPicture;

    [SerializeField]
    private GameObject monsterPicture;
    
    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private Camera SubCamera;

    private int round = 1;

    // Use this for initialization
    void Start () {

        roundText.GetComponent<Text>().text = "Round " + round;
    }
	
	// Update is called once per frame
	void Update () {

        float timer = timerText.GetComponent<Timer>().time;
        if (timer < 1)
        {
            playerPicture.SetActive(true);
        }

        if (Input.GetKeyDown("joystick button 4"))
        {
            monsterPicture.SetActive(true);
            timerText.GetComponent<Timer>().timerflag = false;
            MainCamera.enabled = false;
            SubCamera.enabled = true;
        }

        //Press the spacebar to the next round
        if (Input.GetKeyDown(KeyCode.Space))
        {
            round++;
            //end
            if (round >= 4)
            {

            }
            timerText.GetComponent<Timer>().timerflag = true;
            timerText.GetComponent<Timer>().time = 30.0f;
            playerPicture.SetActive(false);
            monsterPicture.SetActive(false);
            roundText.GetComponent<Text>().text = "Round " + round;
            MainCamera.enabled = true;
            SubCamera.enabled = false;
        }
    }
}
