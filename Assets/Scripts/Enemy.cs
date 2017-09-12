using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //public float acceleration;
    public float maxSpeed;
    public Transform spawnPoint;
    //public float decelerationDrag;
    [HideInInspector]
    public MovementMode movementMode = MovementMode.NavMeshAxis;

    public enum MovementMode { Free, NavMeshClick, NavMeshAxis }

    private Rigidbody rb;
    private NavMeshAgent navAgent;
    [SerializeField]
    private Animator animator;

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

            case MovementMode.NavMeshClick:
                if (rb)
                {
                    rb.isKinematic = true;
                }
                break;
            case MovementMode.NavMeshAxis:
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
                /*float vert = Input.GetAxis("Vertical2");
                float hor = Input.GetAxis("Horizontal2");
                Vector3 velocity = rb.velocity;
                velocity += acceleration * new Vector3(hor, 0f, vert).normalized * Time.deltaTime;
                if (Mathf.Approximately(vert, 0f) & Mathf.Approximately(hor, 0f))
                {
                    velocity = Vector3.MoveTowards(velocity, Vector3.zero, decelerationDrag);
                }
                velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
                rb.velocity = velocity;*/
                break;

            case MovementMode.NavMeshClick:
                /*if (Input.GetMouseButtonDown(0))
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
                }*/
                break;

            case MovementMode.NavMeshAxis:
                Vector3 direction = Vector3.zero;
                direction.z = Input.GetAxisRaw("Vertical2");
                direction.x = Input.GetAxisRaw("Horizontal2");
                navAgent.velocity = direction * maxSpeed;
                break;

            default:
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(Capture(col.GetComponentInParent<Player>()));
        }
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(spawnPoint.position.x, transform.position.y, spawnPoint.position.z);
        navAgent.ResetPath();
    }

    IEnumerator Capture(Player target)
    {
        animator.SetTrigger("Capture");
        target.SetInteractable(false);
        float time = 0f;
        float duration = 0.8f;
        float paraboleHeight = 1f;
        Vector3 startPos = target.transform.position;
        Vector3 endOffset = Vector3.zero;
        Vector3 startScale = target.transform.localScale;
        Vector3 endScale = new Vector3(0.3f, 0.3f, 0.3f);

        while (time <= duration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / duration);
            Vector3 newPos = Vector3.Lerp(startPos, transform.position + endOffset, t);
            newPos.y = newPos.y + Mathf.Sin(t * Mathf.PI) * paraboleHeight;
            target.transform.position = newPos;
            target.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Reset();
        target.Reset();
    }
}
