using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 3f;
    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

}
