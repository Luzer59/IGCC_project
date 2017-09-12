using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //public float acceleration;
    public float maxSpeed;
    public Transform spawnPoint;
    //public float decelerationDrag;

    private Rigidbody rb;
    private NavMeshAgent navAgent;
    private Collider[] col;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponentsInChildren<Collider>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.z = Input.GetAxisRaw("Vertical");
        direction.x = Input.GetAxisRaw("Horizontal");
        navAgent.velocity = direction * maxSpeed;
        /*float vert = Input.GetAxis("Vertical1");
        float hor = Input.GetAxis("Horizontal1");
        Vector3 velocity = rb.velocity;
        velocity += acceleration * new Vector3(hor, 0f, vert).normalized * Time.deltaTime;
        if (Mathf.Approximately(vert, 0f) & Mathf.Approximately(hor, 0f))
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, decelerationDrag);
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        rb.velocity = velocity;*/
    }

    public void Reset()
    {
        SetInteractable(true);
        transform.localScale = Vector3.one;
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(spawnPoint.position.x, transform.position.y, spawnPoint.position.z);
    }

    public void SetInteractable(bool state)
    {
        rb.isKinematic = !state;
        foreach (Collider c in col)
        {
            c.enabled = state;
        }
    }
}
