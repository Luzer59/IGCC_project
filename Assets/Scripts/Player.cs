using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;

    private Rigidbody2D rb;
    private bool grounded = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * moveSpeed * hor * Time.deltaTime);
        if (vert > 0.1f && grounded)
        {
            rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime);
        }
        grounded = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        grounded = true;
    }
}
