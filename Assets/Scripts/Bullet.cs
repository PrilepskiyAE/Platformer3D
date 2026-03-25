using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject eff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(eff,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
