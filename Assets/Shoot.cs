using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce = 5000.0f;
    private Transform firePoint;
    
    [SerializeField]
    public ParticleSystem muzzleParticle;

    [SerializeField]
    public AudioSource gunFireSource;

// Use this for initialization
    void Start () {

    }

// Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            FireGun();
        }
    }

    public int shots = 1;
    private void FireGun()
    {
        //Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        shots++;
        
        muzzleParticle.Play();
        gunFireSource.Play();

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;
        
        muzzleParticle.Stop();
        gunFireSource.Stop();
        if (Physics.Raycast(ray, out hitInfo, 999))
        {

            if (GameObject.FindGameObjectWithTag("Enemy")
                .GetComponent<Enemy>().enemyLife != 0)
                GameObject.FindGameObjectWithTag("Enemy")
                    .GetComponent<Enemy>().enemyLife -= 50;

            if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>
            ().enemyLife <= 0)
            {
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player")
                    .GetComponent<ScoringSystem>().PlayerTakesDamage(-20);
            }
            
        }
    }
    
    
    
    
}
