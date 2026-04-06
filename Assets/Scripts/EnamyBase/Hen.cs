using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeToReachSpeed = 1f;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 force = rb.mass * (direction * speed - rb.linearVelocity) / timeToReachSpeed;
        rb.AddForce(force);

    }
}
