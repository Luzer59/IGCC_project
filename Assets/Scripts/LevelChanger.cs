using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger instance;

    public GameObject fadeCanvasPrefab;
    public float transitionFadeDuration;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLevel(string name)
    {
        StartCoroutine(ChangeLevelCoroutine(name));
    }

    IEnumerator ChangeLevelCoroutine(string name)
    {
        GameObject go = Instantiate(fadeCanvasPrefab);
        go.transform.SetParent(transform);
        FadeCanvas fade = go.GetComponent<FadeCanvas>();
        FadeCanvas.FadeOperation fadeOp = fade.SetFade(FadeCanvas.FadeDirection.FadeIn, transitionFadeDuration);
        while (!fadeOp.complete)
        {
            yield return null;
        }
        SceneManager.LoadScene(name, LoadSceneMode.Single);
        fadeOp = fade.SetFade(FadeCanvas.FadeDirection.FadeOut, transitionFadeDuration);
        while (!fadeOp.complete)
        {
            yield return null;
        }
        Destroy(go);
    }
}
