using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maximumSpeed = 5f;

    private Animator animator;

    public float currentSpeed { get; private set; }

    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        currentSpeed = maximumSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(
                Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );

            rigidBody2D.velocity = new Vector2(currentSpeed, rigidBody2D.velocity.y);
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(
                -Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );

            rigidBody2D.velocity = new Vector2(-currentSpeed, rigidBody2D.velocity.y);
            animator.SetBool("isRunning", true);
        }
        else
        {
            currentSpeed = 0;
            rigidBody2D.velocity = new Vector2(currentSpeed, rigidBody2D.velocity.y);
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = maximumSpeed / 2; 
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }
        else
        {
            currentSpeed = maximumSpeed;
            animator.SetBool("isWalking", false);
        }

        // Stop the rotation of the player
        rigidBody2D.angularVelocity = 0;
    }
}
