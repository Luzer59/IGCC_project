using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField]
    private float speed = 1;

    private Vector3 prev;

    [SerializeField]
    GameObject Speechballoon;

    [SerializeField]
    GameObject attack;

    [SerializeField]
    private bool mode3D = true;

    // Use this for initialization
    void Start () {

        prev = transform.position;
	}
	
	// Update is called once per frame
	void Update () {


        //1フレーム前のポジション　Position one frame before
        prev = transform.position;

        //移動方法　3DMode
        if (mode3D)
        {
            Move3D();
        }
        //移動方法　2DMode
        else
        {
            //not move while attacking
            if (!attack.activeSelf)
            {
                Move2D();
                //Show and hide
                if (prev == transform.position)
                        Speechballoon.SetActive(true);
                    else
                        Speechballoon.SetActive(false);
            }
            //L1trigger Attack 
            if (Input.GetKeyDown("joystick button 4"))
            {
                attack.SetActive(!attack.activeSelf);
                Speechballoon.SetActive(false);
            }
        }
    }

    void Move3D()
    {
        //方向
        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxisRaw("Vertical2");
        direction.x = Input.GetAxisRaw("Horizontal2");

        //移動　move
        if (direction.magnitude < 0.75f) direction = Vector3.zero;

        transform.position += direction * speed * Time.deltaTime;

        //差分　Difference
        Vector3 diff = transform.position - prev;

        //回転　rotation
        if (diff.magnitude > 0.01)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
    }

    void Move2D()
    {
        //方向 direction
        Vector3 direction = Vector3.zero;
        direction.y = Input.GetAxisRaw("Vertical");
        direction.x = Input.GetAxisRaw("Horizontal");
        if (direction.magnitude < 0.75f) direction = Vector3.zero;
        //移動　move
        transform.position += direction * speed * Time.deltaTime;
    }
}
