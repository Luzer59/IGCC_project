using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public StageJudge cont;
    public AudioSource source;
    public AudioClip firstBGM;
    public AudioClip endBGM;

    void Start()
    {
        cont.roundChanged += RoundChanged;
        source.clip = firstBGM;
        source.Play();
    }

    void RoundChanged(int round)
    {
        if (round < 3)
        {
            source.Stop();
            source.clip = firstBGM;
            source.Play();
        }
        else
        {
            source.Stop();
            source.clip = endBGM;
            source.Play();
        }
    }
}
