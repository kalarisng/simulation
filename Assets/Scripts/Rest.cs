using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : MonoBehaviour
{
    public PlayerHealthBar playerHealthBar;
    public float healthIncreaseInterval = 0.5f; // Time interval between each health increment
    public int healthIncreaseAmount = 5; // Amount of health to increase each increment

    private bool isResting = false; // Flag to track if the player is currently resting
    private float healthIncreaseTimer = 0f; // Timer to track the time passed since the last health increment

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isResting)
            {
                if (playerHealthBar.currentHealth < 100)
                {
                    // alert canvas activated
                    isResting = true;
                    healthIncreaseTimer = 0f;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            isResting = false;
        }

        if (isResting)
        {
            healthIncreaseTimer += Time.deltaTime;

            if (healthIncreaseTimer >= healthIncreaseInterval)
            {
                IncrementHealth();
                healthIncreaseTimer = 0f;
            }
        }
    }

    void IncrementHealth()
    {
        if (playerHealthBar.currentHealth < playerHealthBar.maxHealth)
        {
            playerHealthBar.currentHealth += healthIncreaseAmount;
            playerHealthBar.currentHealth = Mathf.Min(playerHealthBar.currentHealth, playerHealthBar.maxHealth);
            playerHealthBar.healthBar.SetHealth(playerHealthBar.currentHealth);
        }
    }
}
