using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public Transform spawnPoint;
    public float decelerationDrag;

    private Rigidbody rb;
    private NavMeshAgent navAgent;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        if (navAgent != null && rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        if (navAgent == null && rb != null)
        {
            float vert = Input.GetAxis("Vertical2");
            float hor = Input.GetAxis("Horizontal2");
            Vector3 velocity = rb.velocity;
            velocity += acceleration * new Vector3(hor, 0f, vert).normalized * Time.deltaTime;
            if (Mathf.Approximately(vert, 0f) & Mathf.Approximately(hor, 0f))
            {
                velocity = Vector3.MoveTowards(velocity, Vector3.zero, decelerationDrag);
            }
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            rb.velocity = velocity;
        }
        if (navAgent != null)
        {
            
        }
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
