using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject cloud;
    private int score;
    private int playerLives = 3;  // Player's initial lives
    
    public TextMeshProUGUI scoreText;  // Reference to score display
    public TextMeshProUGUI livesText;  // Reference to lives display

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + playerLives;  // Initialize lives display
    }

    // Update is called once per frame
    void Update()
    {
        // Any other update logic you need
    }

    public void LoseLife()
    {
        playerLives--;  // Decrease lives by 1
        livesText.text = "Lives: " + playerLives;  // Update the UI text to show remaining lives
        
        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    void CreateEnemy()
    {
        // Random position for enemies, but ensure they spawn above the screen
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        // Creating clouds in random positions across the screen
        for (int i = 0; i < 30; i++)
        {
            Vector3 cloudPosition = new Vector3(Random.Range(-9f, 9f), Random.Range(5f, 10f), 0);  // Random y position for variety
            Instantiate(cloud, cloudPosition, Quaternion.identity);
        }
    }

    public void EarnScore(int howMuch)
    {
        score += howMuch;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // Game over logic here
        CancelInvoke("CreateEnemy");  // Stops enemy spawning
        // Trigger game over UI or restart
    }
}

