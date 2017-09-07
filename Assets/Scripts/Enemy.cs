using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveXSpeed;
    public float moveYSpeed;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float vert = Input.GetAxis("AIVertical");
        float hor = Input.GetAxis("AIHorizontal");

        rb.AddForce(Vector2.right * moveXSpeed * hor * Time.deltaTime);
        rb.AddForce(Vector2.up * moveYSpeed * vert * Time.deltaTime);
    }
}
