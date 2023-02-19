using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    private float NextFire = 0f;
    public float force = 100f;
    public Camera fpsCam;
    public Transform bulletSpawner;
    public ParticleSystem muzzleflash;
    public AudioSource audioSource;
    public AudioClip audioClip;
   
   
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Time.time > NextFire)    
        {
            NextFire = Time.time + 1f / fireRate;
            Shoot();
        }

        void Shoot()
        {
            audioSource.PlayOneShot(audioClip);
            //Instantiate(muzzleflash, bulletSpawner.position,bulletSpawner.rotation);
            muzzleflash.Play();

            RaycastHit hit;

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
            {
                Debug.Log(hit.transform.name);
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * force);
                }
            }

           Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
            

        }
    }
}
