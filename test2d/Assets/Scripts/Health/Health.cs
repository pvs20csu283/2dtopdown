using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public CharacterScriptableObject characterData;


   public float maxHealth = 100;
    public float currentHealth;

    void Awake()
    {
        maxHealth = characterData.MaxHealth;
    }

    void Start()
    {
        currentHealth = maxHealth; //at the start of the game
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //we're dead
            //play game over screen
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
