using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float ClimbSpeed = 10f;
    CapsuleCollider2D myCapsuleCollider;
    CircleCollider2D myCircleCollider;
    Animator myAnimator;
    float gravityScaleAtStart;
    bool isAlive = true;
    // [SerializeField] float jumpSpeed = 500;
    
    Vector2 moveInput;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        myCircleCollider = GetComponent<CircleCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive) {return;}
        Run();
        flipSprite();
        Climb();
        Die();
    }

    private void Die()
    {
        if(myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void OnJump(InputValue value)
    {
        if(!isAlive) {return;}
        if(!myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}
        if(value.isPressed)
        {
            rb.velocity += new Vector2 (0f, jumpSpeed);
        }
    }
    void Run()
    {
        if(!isAlive) {return;}
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
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
        if(!isAlive) {return;}
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
        }
    }
    void Climb()
    {
        if(!isAlive) {return;}
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("ClimbingLayer"))) 
        {
            rb.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false); 
            return;
            
        }
        else
        {
            rb.gravityScale = 0f;
            Vector2 playerVelocity = new Vector2 (rb.velocity.x, moveInput.y * ClimbSpeed);
            rb.velocity = playerVelocity;
            bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
        }
    }

}
