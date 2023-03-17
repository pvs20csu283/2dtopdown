using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    //currentStats
    //float currentHealth;
    float currentRecovery;
    float currentMoveSpeed;


    void Awake()
    {
        //currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
