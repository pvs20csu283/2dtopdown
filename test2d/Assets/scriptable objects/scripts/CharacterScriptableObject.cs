using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Charater")]

public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    float maxHealth;

    public float MaxHealth
    {
        get => maxHealth;

        private set => maxHealth = value;
    }

    [SerializeField]
    float recovery;

    public float Recovery
    {
        get => recovery;

        private set => recovery = value;
    }


    [SerializeField]
    float moveSpeed;

    public float MoveSpeed
    {
        get => moveSpeed;

        private set => moveSpeed = value;
    }

}
