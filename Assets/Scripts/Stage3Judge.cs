using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage3Judge : MonoBehaviour {

    [SerializeField]
    private GameObject timerText;

    [SerializeField]
    private GameObject roundText;

    [SerializeField]
    private GameObject playerPicture;

    [SerializeField]
    private GameObject monsterPicture;

    [SerializeField]
    private GameObject monster;

    private Vector3 monsterpos;

    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private Camera SubCamera;

    private int round = 1;

    // Use this for initialization
    void Start () {
        roundText.GetComponent<Text>().text = "Round " + round;
        monsterpos = monster.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float timer = timerText.GetComponent<Timer>().time;
        if (timer < 1) 
        {
            playerPicture.SetActive(true);
        }
        else if (Input.GetKeyDown("joystick button 4"))
        {
            monsterPicture.SetActive(true);
            timerText.GetComponent<Timer>().timerflag = false;
        }
        
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
            monster.transform.position = monsterpos;
            MainCamera.enabled = true;
            SubCamera.enabled = false;
        }
    }
}
