using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script
    public float healthIncreaseDuration = 5f; // Duration in seconds for the health increase
    public float maxIncreaseAmount = 100f; // Maximum amount to increase the health bar

    private bool isResting = false; // Flag to track if the player is currently resting
    private float currentIncreaseTimer = 0f; // Timer for the current health increase
    private float initialHealth; // Initial health value before resting

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isResting)
            {
                if (healthBar.slider.value <= 0)
                {
                    isResting = true;
                    currentIncreaseTimer = 0f;
                    initialHealth = healthBar.slider.value;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            isResting = false;
        }

        if (isResting)
        {
            currentIncreaseTimer += Time.deltaTime;

            float normalizedTimer = currentIncreaseTimer / healthIncreaseDuration;
            float increasedAmount = Mathf.Lerp(0f, maxIncreaseAmount, normalizedTimer);

            float targetHealth = initialHealth + increasedAmount;
            float clampedHealth = Mathf.Clamp(targetHealth, initialHealth, healthBar.slider.maxValue);

            healthBar.SetHealth(Mathf.FloorToInt(clampedHealth));

            if (currentIncreaseTimer >= healthIncreaseDuration)
            {
                isResting = false;
            }
        }
    }
}
