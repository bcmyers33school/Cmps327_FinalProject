using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{

    public Slider healthBar;
    public GameObject scoreText;
    public int Health = 100;
    public static bool bonusTime;
    private int _currentHealth;
    void Start()
    {
        bonusTime = false; // Keeps track if the player grabs the powerup
    }
    void Update()
    {
        // Update the score text on the HUD
        scoreText.GetComponent<Text>().text = "HEALTH: " + Health;

        // If the score drops below or is equal to 0, then Game Over
        if(Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        // If the score reaches over 300 points, the player wins
        if (Health >= 300)
        {
            SceneManager.LoadScene("GameWin");
        }
        // If the player grabs the power up, then they become invincible.
        if (bonusTime == true)
        {
            StartCoroutine(Invincible());
        }
    }

    public void PlayerTakesDamage(int damage)
    {
        Health -= damage;
        healthBar.value = Health;
    }
    
    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(10f);
        ScoringSystem.bonusTime = false;
    }
}
