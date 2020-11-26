using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private GameObject enemy;

    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Player");
    }
    
    void OnTriggerEnter(Collider c)
    {

        if (c.CompareTag("Enemy"))
        {
            c.gameObject.GetComponent<Enemy>().enemyLife -= 50;
            if (c.GetComponent<Enemy>().enemyLife >= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<ScoringSystem>().PlayerTakesDamage(-10);
            }
        }
        else
        {
            return;
        }

    }
}