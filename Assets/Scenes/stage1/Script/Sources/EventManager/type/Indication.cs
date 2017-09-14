using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indication : ScriptEvent {

    public static Indication insrance;

    private GameObject obj;

    void Awake()
    {
        if (!insrance)
        {
            insrance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public Indication GetscriptEvent(int _lifetime,GameObject _object)
    {
        Indication data = Instantiate(insrance);
        data.lifetime = _lifetime;
        data.objec = _object;

        //Hide
        data.objec.SetActive(false);

     
        return data;
    }

    public override void Run()
    {
        if (lifetime < 0 || objec == null)
        {
            Debug.Log("ok");

            gameObject.SetActive(false);
            objec.SetActive(true);


            return;
        }

        lifetime--;
    }
}
