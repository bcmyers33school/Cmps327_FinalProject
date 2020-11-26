using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class CollectMega : MonoBehaviour
{
    public AudioSource collectSound;

    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            return;
        }
        
        if (other.CompareTag("Projectile"))
        {
            return;
        }
        
        Destroy(gameObject);
        ScoringSystem.bonusTime = true;
        collectSound.Play();
        FindObjectOfType<ScoringSystem>().PlayerTakesDamage(-50);
        

    }


}
