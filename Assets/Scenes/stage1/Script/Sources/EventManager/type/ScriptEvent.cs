using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEvent : MonoBehaviour {

    public int lifetime;

    public GameObject objec;

    virtual public void Run()
    {
        if (lifetime < 0)
            return;

        lifetime--;
    }

    

}
