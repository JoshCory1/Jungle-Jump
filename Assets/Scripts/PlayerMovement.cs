using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    Animator myAnimator;
    // [SerializeField] float jumpSpeed = 500;
    
    Vector2 moveInput;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        flipSprite();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = playerVelocity;
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }
    void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}