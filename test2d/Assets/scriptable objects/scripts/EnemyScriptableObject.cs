using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName ="ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    //stats for the enemy

    [SerializeField]

    public float moveSpeed;

    public float MoveSpeed
    {
        get => moveSpeed;

        private set => moveSpeed = value;
    }

    [SerializeField]
    public float maxHealth;

    public float MaxHealth
    {
        get => maxHealth;

        private set => maxHealth = value;
    }

    [SerializeField]
    public int damage;

    public int Damage
    {
        get => damage;

        private set => damage = value;
    }
}
