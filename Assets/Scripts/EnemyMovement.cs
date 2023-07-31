using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1;
    BoxCollider2D myBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (moveSpeed, 0);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        flipEnemyFaceing();    
    }

    private void flipEnemyFaceing()
    {    
        transform.localScale = new Vector2 (-(Mathf.Sign(rb.velocity.x)), 1f);
    
    }
}
