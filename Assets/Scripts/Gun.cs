using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotpir;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject flash;
    [SerializeField] private PlayerAnimation _playerAnimation;
    private float timer;

   
    void Update()
    { 
        timer+=Time.deltaTime;
        if (timer > shotpir)
        {
            if (Input.GetMouseButton(0))
            {
            flash.SetActive(true);    
            timer=0;  
            audioSource.Play();  
             if (_playerAnimation != null)
                {
                _playerAnimation.GunAnimation(); 
                }  
            GameObject newBull = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation); 
            newBull.GetComponent<Rigidbody>().linearVelocity = bulletSpawnPoint.forward * bulletSpeed;
               
            Invoke("HigeFlash",0.08f);

            }

        }
       
    }

    public void HigeFlash()
    {
        flash.SetActive(false);
    }

}
