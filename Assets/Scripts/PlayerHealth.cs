using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int health = 5;
   [SerializeField] int maxHealth = 8;

   private bool _invulnerable = false;

   public void TakeDamage(int damage)
    {
        if (_invulnerable==false){
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        _invulnerable = true;
        Invoke("StopInvulnerability",1f);
        }
    }

    void StopInvulnerability()
    {
        _invulnerable = false;
    }

    public void Die()
    {
        Debug.Log("Player is dead");
    }
    public void AddHeal(int value)
    {
        if (health < maxHealth)
        {
            health += value;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

    }
}
