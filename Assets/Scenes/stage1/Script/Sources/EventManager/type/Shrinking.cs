using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinking : ScriptEvent {

    public static Shrinking insrance;

    private Vector3 scale;
    private int maxlifetime;

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

    public Shrinking GetscriptEvent(int _lifetime, Vector3 _scale, GameObject _object)
    {
        Shrinking data = Instantiate(insrance);
        data.lifetime = _lifetime;
        data.maxlifetime = _lifetime;
        data.scale = _scale;
        data.objec = _object;
        Animator anm = data.gameObject.GetComponent<Animator>();

        return data;
    }
    
    public override void Run()
    {
        if (lifetime < 0 || objec == null)
            return;


        //objec.gameObject.transform.localScale -= (scale / maxlifetime);

        lifetime--;
    }

}
