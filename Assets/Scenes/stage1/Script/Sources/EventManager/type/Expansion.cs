using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : ScriptEvent {

    public static Expansion insrance;

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

    public Expansion GetscriptEvent(int _lifetime,Vector3 _scale,GameObject _object)
    {
        Expansion data = Instantiate(insrance);
        data.lifetime = _lifetime;
        data.maxlifetime = _lifetime;
        data.scale = _scale;
        objec = _object;


        return data;
    }

    public override void Run()
    {
        if (lifetime < 0||objec==null)
            return;


        objec.gameObject.transform.localScale += (scale / maxlifetime);

        lifetime--;
    }

}
