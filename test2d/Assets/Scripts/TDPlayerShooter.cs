using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDPlayerShooter : MonoBehaviour
{
    private Vector2 mouseFacing; // mousePosition

    public Camera _camera; // camera variable to know the position of the mouse

    public Rigidbody2D rb;

    public Weapon weapon; //referencing the weapon script

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



    void Update()
    {
        PlayerAim();
    }

    private void PlayerAim()
    {
        //to get the position of the mouse
        Vector2 mouseFacing = controls.Player.MousePosition.ReadValue<Vector2>(); // reading in the value of CURRENT mouse position

        //mouseFacing.Normalize();;

        mouseFacing = _camera.ScreenToWorldPoint(mouseFacing);  //getting reference to main camera and passing out screen coordinates


        transform.up = mouseFacing - new Vector2(transform.position.x, transform.position.y);

        transform.up.Normalize();

        /*Vector2 targetDirection = (mouseFacing - rb.position);

       // targetDirection.Normalize();

        //to get the angle to rotate in our desired position
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
       
        rb.rotation = angle;*/
    }
}
