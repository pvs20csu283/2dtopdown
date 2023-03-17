using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected float currentDamage;
    protected float currentPierce;

    public Rigidbody2D bulletRigidbody;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentPierce = weaponData.Pierce;
    }

    private void OnEnable()
    {
        Invoke("Disable",2f);
    }



    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //referencing the script from the collided collider and dealing damage using TakeDamage function
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
    }

    void ReducePierce() //to destroy once pierce == 0
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
