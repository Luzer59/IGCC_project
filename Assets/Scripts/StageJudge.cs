using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageJudge : MonoBehaviour
{

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

    public event System.Action<int> roundChanged = delegate { };
    public AudioSource aSource;
    public AudioClip playerWinSound;
    public AudioClip enemyWinSound;

    // Use this for initialization
    protected virtual void Start()
    {

        roundText.GetComponent<Text>().text = "Round " + round;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        float timer = timerText.GetComponent<Timer>().time;
        if (timer < 1)
        {
            playerPicture.SetActive(true);
            aSource.PlayOneShot(playerWinSound);
        }

        if (Input.GetKeyDown("joystick button 4"))
        {
            monsterPicture.SetActive(true);
            timerText.GetComponent<Timer>().timerflag = false;
            MainCamera.enabled = false;
            SubCamera.enabled = true;
            aSource.PlayOneShot(enemyWinSound);
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
            roundChanged.Invoke(round);
        }
    }
}
