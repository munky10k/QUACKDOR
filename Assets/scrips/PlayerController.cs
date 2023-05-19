using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float horizontalInput;
    public bool isOnGround = true;
    public float jumpForce;
    public float lowerLimit;
    public Animator animator;
    public GameObject pp;
    public GameObject cs;
    public float lives;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lives = 3;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);
        if (horizontalInput < 0)
        {
            sr.flipX = true;
            animator.SetFloat("moveSpeed", moveSpeed);
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
            animator.SetFloat("moveSpeed", moveSpeed);
        }
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
