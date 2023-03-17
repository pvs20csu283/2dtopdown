using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDPlayerMovement : MonoBehaviour
{
    public CharacterScriptableObject characterData;


    public Rigidbody2D rb; // rigidbody

    private float InputX; //X axis input

    private float InputY; //Y axis input

   // public float moveSpeed; speed variable

    private TDActions controls; //calling the new input system controls


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

    }


    void Update()
    {
        Move();
    }
    
    void FixedUpdate() //gets called a set amount of time per frame. Physics Calcs
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
         InputX = controls.Player.Movement.ReadValue<Vector2>().x;
         InputY = controls.Player.Movement.ReadValue<Vector2>().y;

    }      

    private void Move()
    {
        transform.Translate(new Vector3(InputX, InputY, 0) * characterData.MoveSpeed * Time.deltaTime);
    }

}
