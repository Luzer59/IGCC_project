using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField]
    private float speed = 1;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //方向
        Vector3 direction = Vector3.zero;


        //入力
        if (Input.GetAxisRaw("Vertical2") < 0)
        {
            //上に傾いている UP
            direction.y = -1.0f;
        }
        else if (0 < Input.GetAxisRaw("Vertical2"))
        {
            //下に傾いている DOWN
            direction.y = 1.0f;
        }
        if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            //左に傾いている LEFT
            direction.x = -1.0f;
        }
        else if (0 < Input.GetAxisRaw("Horizontal2"))
        {
            //右に傾いている RIGHT
            direction.x = 1.0f;
        }

        //移動　move
        transform.position += direction * speed * Time.deltaTime;
    }
}
