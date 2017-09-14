using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage3Judge : StageJudge
{
    [SerializeField]
    private GameObject monster;

    private Vector3 monsterpos;

    protected override void Start()
    {
        base.Start();
        monsterpos = monster.transform.position;
        //monster.GetComponent<Enemy>().movementMode = Enemy.MovementMode.Free;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

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
            monster.transform.position = monsterpos;
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
            InvokeRoundChanged(round);
        }
    }
}
