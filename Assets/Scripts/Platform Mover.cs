using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{

    public Transform posA, posB;
    public int speed;
    Vector3 targetpos;


    // Start is called before the first frame update
    void Start()
    {
        targetpos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f) 
        {
            targetpos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.05f) 
        {
            targetpos = posA.position;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
