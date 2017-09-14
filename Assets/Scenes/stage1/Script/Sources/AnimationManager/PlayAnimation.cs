using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

    [SerializeField, Header("AnimationManager")]
    public GameObject animationmanager;

    [SerializeField, Header("Name")]
    public string AnimationName;

    private void Update()
    {
        animationmanager.GetComponent<AnimationManager>().PlayAnimation(AnimationName);
        this.gameObject.SetActive(false);
    }


}
