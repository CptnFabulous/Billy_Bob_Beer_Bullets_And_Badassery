using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float criticalPercentage;

    int prevHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        OnHealthChanged();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (prevHealth != currentHealth) // If health has changed since last frame
        {
            OnHealthChanged();
        }
    }

    public virtual void Damage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtracts from currentHealth
        // do other stuff e.g. damage animations
    }

    public virtual void Heal(int healAmount)
    {
        currentHealth += healAmount; // Adds to currentHealth
        // do other stuff e.g. heal animations
    }

    public virtual void OnHealthChanged() // Performs appropriate actions when health changes
    {
        if (currentHealth <= 0) // If health is less than zero
        {
            Die();
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensures health does not exceed limits

        prevHealth = currentHealth; // Updates prevHealth variable to match new health
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        // Add other stuff in derived class
    }
}
