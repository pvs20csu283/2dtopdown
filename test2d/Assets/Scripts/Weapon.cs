using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    public GameObject bullet;
    public Transform firePoint; // a position to instantiate our bullets from.

    //public float force;  firing force

    private TDActions controls;

    private void Awake()
    {
        controls = new TDActions();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Player.Shoot.performed += _ => Fire();
    }

    public void Fire()
    {
        //GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = firePoint.position;
        obj.transform.rotation = firePoint.rotation;
        obj.SetActive(true);



        obj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * weaponData.Speed, ForceMode2D.Impulse);
    }
}
