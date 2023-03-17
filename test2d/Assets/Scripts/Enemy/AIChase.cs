using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    public GameObject player;


    private float distance;
    //public float distanceBetween;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); //takes two transforms and takes distance between them
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

       /*/ if (distance < distanceBetween)
        {

        }*/
        //to move the enemy towards a certain position
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
