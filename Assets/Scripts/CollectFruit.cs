using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour {

    public AudioSource collectSound;

	// Update is called once per frame
	void Update () {
        // Rotate the object on the y axis. 
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
        
        // Plays sound when collided into
        collectSound.Play();
         
        // If the Player has not picked up the MegaFruit, then 20 points are added to the score when the fruit is picked up.
        if (ScoringSystem.bonusTime == false)
        {
            Destroy(gameObject);
            FindObjectOfType<ScoringSystem>().PlayerTakesDamage(-20);
        }

        // If the Player has picked up the MegaFruit, then 40 points are added to the score when the fruit is picked up. 
        else
        {
            Destroy(gameObject);
            FindObjectOfType<ScoringSystem>().PlayerTakesDamage(-40);
        }

    }
}
