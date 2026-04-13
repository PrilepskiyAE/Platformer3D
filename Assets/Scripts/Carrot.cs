using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float upwardForce = 2f; // Сила подъёма вверх

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = (player.position - transform.position).normalized;

        // Задаём начальную скорость: горизонтальное направление + небольшой подъём вверх
        rb.linearVelocity = direction * speed + Vector3.up * upwardForce;
    }
}