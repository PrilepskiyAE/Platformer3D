using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] 
    private int heal = 1;
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
        
        other.attachedRigidbody.GetComponent<PlayerHealth>().AddHeal(heal);
        Destroy(gameObject);
            
        }
    }

}
