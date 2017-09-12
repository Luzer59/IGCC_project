using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    [SerializeField, Header("Object")]
    public GameObject gameobj;

    [SerializeField, Header("Animator")]
    public Animator animator;

    private void Start()
    {
        animator = gameobj.GetComponent<Animator>();
    }

    //PlayAnimation
    public void PlayAnimation(string _name)
    {
        animator.CrossFade(_name, 0);
    }

}