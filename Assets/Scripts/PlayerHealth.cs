using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField]private  int maxHealth = 8;

    [SerializeField]private  AudioSource addHeal;

    [SerializeField] private HealthUI healthUI;


    [SerializeField] private UnityEvent eventOnTakeDamage;

    void Start()
    {
        healthUI.SetupHealth(maxHealth);
        healthUI.UpdateHealth(health);
    }

    private bool _invulnerable = false;

    public void TakeDamage(int damage)
    {
        if (_invulnerable == false)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerability", 1f);
        }
        healthUI.UpdateHealth(health);
   

        eventOnTakeDamage.Invoke();
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
            addHeal.Play();
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        healthUI.UpdateHealth(health);
    }
}
