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
    private GameObject playerText;

    [SerializeField]
    private GameObject monsterText;

    [SerializeField]
    private GameObject attack;

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
            playerText.SetActive(true);
        }
        else if (Input.GetKeyDown("joystick button 4"))
        {
            monsterText.SetActive(true);
            timerText.GetComponent<Timer>().timerflag = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timerText.GetComponent<Timer>().timerflag = true;
            timerText.GetComponent<Timer>().time = 30.0f;
            playerText.SetActive(false);
            monsterText.SetActive(false);
            round++;
            roundText.GetComponent<Text>().text = "Round " + round;
            attack.SetActive(false);
        }
    }
}
