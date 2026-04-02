using UnityEngine;

public class TakeDamageOnColision : MonoBehaviour
{
    [SerializeField] EnamyHealth _enamyHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                _enamyHealth.TakeDamage(1);
            }
        }

    }
}
