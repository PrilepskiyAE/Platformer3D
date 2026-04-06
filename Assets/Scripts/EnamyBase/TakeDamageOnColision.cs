using UnityEngine;

public class TakeDamageOnColision : MonoBehaviour
{
    [SerializeField] EnamyHealth _enamyHealth;
    [SerializeField] int damage=1;

    [SerializeField] bool dieOnAnyColision=false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                _enamyHealth.TakeDamage(damage);
            }
        }

        if (dieOnAnyColision)
        {
             _enamyHealth.TakeDamage(10000);
        }

    }
}
