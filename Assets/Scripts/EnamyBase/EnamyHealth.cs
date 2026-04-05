using UnityEngine;
using UnityEngine.Events;

public class EnamyHealth : MonoBehaviour
{
   [SerializeField] private int health;
    [SerializeField] private UnityEvent eventeTakeDamage;
   
    public void TakeDamage(int damage)
    {
        health-=damage;
        if (health <= 0)
        {
            Die();
        }
        eventeTakeDamage.Invoke();
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
