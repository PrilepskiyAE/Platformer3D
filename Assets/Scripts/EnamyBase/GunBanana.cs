using UnityEngine;

public class GunBanana : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotInterval;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private DetectedPlayer _detectedPlayer;

    private float timer;



    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shotInterval)
        {
            if (_detectedPlayer.IsPlayerDetected())
            {

                timer = 0;
                audioSource.Play();

                GameObject newBull = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Rigidbody rb = newBull.GetComponent<Rigidbody>();
               if (rb != null)
                {
                    
                    rb.linearVelocity = transform.forward * bulletSpeed;

                    
                    rb.linearVelocity += Vector3.up * (bulletSpeed * 1.5f);
                }

            }

        }

    }


}