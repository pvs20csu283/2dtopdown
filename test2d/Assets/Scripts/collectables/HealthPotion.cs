using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public int healthToRestore;

    public void Collect()
    {
        Health player = FindObjectOfType<Health>();
        player.Heal(healthToRestore);
        Destroy(gameObject);
    }
}
