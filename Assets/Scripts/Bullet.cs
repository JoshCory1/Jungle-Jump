using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    float xSpeed;
    PlayerMovement Player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();  
        xSpeed = Player.transform.localScale.x * speed;  
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, 0f);   
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }    
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);    
    }
}
