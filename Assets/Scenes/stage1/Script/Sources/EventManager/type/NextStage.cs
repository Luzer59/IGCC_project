using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour {

    public int movetime;
	
	// Update is called once per frame
	void Update () {
        if (movetime < 0)
        {
            Debug.Log("ok");
            //movestage

            SceneManager.LoadScene("stage2");

            return;
        }



        movetime--;

	}
}
