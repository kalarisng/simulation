using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private bool isTakingDamage = false;
    private float damageInterval = 0.5f; // Time interval between each damage tick
    private float damageTimer = 0f; // Timer to track the time passed since the last damage tick

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            isTakingDamage = true;
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                TakeDamage(5);
                damageTimer = 0f;
            }
        }
        else
        {
            isTakingDamage = false;
            damageTimer = 0f;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure currentHealth doesn't fall below 0
        healthBar.SetHealth(currentHealth);
    }
}
