using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotpir;
    private float timer;

   
    void Update()
    { 
        timer+=Time.deltaTime;
        if (timer > shotpir)
        {
            if (Input.GetMouseButton(0))
            {
            timer=0;    
            GameObject newBull = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation); 
            newBull.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
        }
       
    }
}
