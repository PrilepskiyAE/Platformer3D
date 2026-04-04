using UnityEngine;

public class TakeDamageOnColision : MonoBehaviour
{
    [SerializeField] EnamyHealth _enamyHealth;
    [SerializeField] int damage=1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                _enamyHealth.TakeDamage(damage);
            }
        }

    }
}
