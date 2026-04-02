using UnityEngine;

public class EnamyHealth : MonoBehaviour
{
    public int Health;
   
    public void TakeDamage(int damage)
    {
        Health-=damage;
        if (Health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
