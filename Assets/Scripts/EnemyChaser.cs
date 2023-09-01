using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    //For the chase part
    public GameObject player;
    private Transform playerPos;
    public float distance;
    public float chaseSpeed;

    //For the patrol part
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float patrolSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            Vector2 direction = playerPos.position - transform.position;
            Vector2 movement = direction.normalized * chaseSpeed;
            movement.y = 0;
            rb.velocity = movement;

            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, chaseSpeed * Time.deltaTime);
        }
        else
        {
            //Removes the check here since currentPos is always equal to transform.position
            Patrol();
        }
    }

    void Patrol()
    {
        Vector2 direction = currentPoint.position - transform.position;

        Vector2 movement = direction.normalized * patrolSpeed;
        movement.y = 0;
        rb.velocity = movement;

        if (Mathf.Abs(currentPoint.position.x - transform.position.x) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        else if (Mathf.Abs(currentPoint.position.x - transform.position.x) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
