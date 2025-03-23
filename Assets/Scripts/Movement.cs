using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maximumSpeed = 5f;

    [SerializeField] private Animator animator;

    public float currentSpeed { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        else
        {
            currentSpeed = 0;
            transform.Translate(Vector3.right * currentSpeed);
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
            transform.Translate(Vector3.right * 0);
            animator.SetBool("isWalking", false);
        }
    }
}
