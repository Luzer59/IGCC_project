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
    public MovementMode movementMode;

    public enum MovementMode { Free, NavMeshAI }

    private Rigidbody rb;
    private NavMeshAgent navAgent;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>(); 
    }

    void Start()
    {
        switch (movementMode)
        {
            case MovementMode.Free:
                if (navAgent)
                {
                    navAgent.enabled = false;
                }
                break;

            case MovementMode.NavMeshAI:
                if (rb)
                {
                    rb.isKinematic = true;
                }
                break;

            default:
                break;
        }
    }

    void Update()
    {
        switch (movementMode)
        {
            case MovementMode.Free:
                if (navAgent)
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
                break;

            case MovementMode.NavMeshAI:
                if (rb)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                        {
                            NavMeshHit navHit;
                            if (NavMesh.SamplePosition(hit.point, out navHit, navAgent.height * 2, 1))
                            {
                                navAgent.SetDestination(navHit.position);
                            }
                        }
                    }
                }
                break;

            default:
                break;
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
