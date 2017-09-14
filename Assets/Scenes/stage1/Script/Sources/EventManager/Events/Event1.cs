using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour {

    [SerializeField, Header("Object")]
    public GameObject gameobj;

    [SerializeField, Header("LifeTime")]
    public int lifetime;

    [SerializeField, Header("Scale")]
    public Vector3 vec3;

    private Animator anm;

    // Update is called once per frame
    void Update () {

        if (gameobj==null)
        {
            this.gameObject.SetActive(false);
            return;
        }


        
        //expention
        EventManager.instance.AddEvent(Shrinking.insrance.GetscriptEvent(lifetime, vec3, gameobj));

        anm = gameobj.GetComponent<Animator>();
        anm.CrossFade("Shrinking", 0);

        
 


        this.gameObject.SetActive(false);

	}
}
