using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageJudge : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent gameEnd;


    [SerializeField]
    protected GameObject timerText;

    [SerializeField]
    protected GameObject roundText;

    [SerializeField]
    protected GameObject playerPicture;

    [SerializeField]
    protected GameObject monsterPicture;

    [SerializeField]
    protected Camera MainCamera;

    [SerializeField]
    protected Camera SubCamera;

    protected int round = 1;

    public event System.Action<int> roundChanged = delegate { };
    public AudioSource aSource;
    public AudioClip playerWinSound;
    public AudioClip enemyWinSound;
    public Player player;
    public Enemy enemy;

    private Coroutine cor = null;

    // Use this for initialization
    protected virtual void Start()
    {

        roundText.GetComponent<Text>().text = "Round " + round;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        float timer = timerText.GetComponent<Timer>().time;
        if (timer < 1 && cor == null)
        {
            cor = StartCoroutine(ChangeRoundPlayer());
        }
    }

    public IEnumerator ChangeRoundPlayer()
    {
        playerPicture.SetActive(true);
        timerText.GetComponent<Timer>().timerflag = false;
        if (player)
        {
            player.enabled = false;
        }
        if (enemy)
        {
            enemy.enabled = false;
        }
        aSource.PlayOneShot(playerWinSound);
        yield return new WaitForSeconds(5f);

        if (round == 3)
        {
            gameEnd.Invoke();
        }
        else
        {
            print("Player win");
            round++;
            timerText.GetComponent<Timer>().timerflag = true;
            timerText.GetComponent<Timer>().time = 30.0f;
            playerPicture.SetActive(false);
            monsterPicture.SetActive(false);
            roundText.GetComponent<Text>().text = "Round " + round;
            if (player)
            {
                player.enabled = true;
            }
            if (enemy)
            {
                enemy.enabled = true;
            }
            player.Reset();
            enemy.Reset();
            roundChanged.Invoke(round);
        }
        cor = null;
    }

    public IEnumerator ChangeRoundEnemy()
    {
        monsterPicture.SetActive(true);
        timerText.GetComponent<Timer>().timerflag = false;
        MainCamera.enabled = false;
        SubCamera.enabled = true;
        aSource.PlayOneShot(enemyWinSound);
        yield return new WaitForSeconds(5f);

        if (round == 3)
        {
            gameEnd.Invoke();
        }
        else
        {
            print("Enemy win");
            round++;
            timerText.GetComponent<Timer>().timerflag = true;
            timerText.GetComponent<Timer>().time = 30.0f;
            playerPicture.SetActive(false);
            monsterPicture.SetActive(false);
            roundText.GetComponent<Text>().text = "Round " + round;
            MainCamera.enabled = true;
            SubCamera.enabled = false;
            roundChanged.Invoke(round);
        }
        cor = null;
    }

    protected void InvokeRoundChanged(int round)
    {
        roundChanged.Invoke(round);
    }
}
