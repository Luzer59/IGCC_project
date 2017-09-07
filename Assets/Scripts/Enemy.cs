using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public Transform spawnPoint;
    public float decelerationDrag;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vert = Input.GetAxis("AIVertical");
        float hor = Input.GetAxis("AIHorizontal");
        Vector3 velocity = rb.velocity;
        velocity += acceleration * new Vector3(hor, 0f, vert).normalized * Time.deltaTime;
        if (Mathf.Approximately(vert, 0f) & Mathf.Approximately(hor, 0f))
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, decelerationDrag);
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        rb.velocity = velocity;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            Reset();
            col.collider.GetComponentInParent<Player>().Reset();
        }
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(spawnPoint.position.x, transform.position.y, spawnPoint.position.z);
    }
}
