using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the ball movement
    public float jumpForce = 5.0f; // Force of the jump
    public float grappleForce = 10.0f; // Force of the grappling pull
    private bool isGrounded = true; // Check if the ball is on the ground
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    private bool isGrappling = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Initially no line
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Grapple();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Jump()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Prevents jumping in mid-air
            Debug.Log("Jumped: " + Time.time);
        }
    }

    void Grapple()
    {
        if (Input.GetKeyDown(KeyCode.G) && !isGrappling)
        {
            isGrappling = true;
            lineRenderer.positionCount = 2; // Two points: start and end of the line
            lineRenderer.SetPosition(0, transform.position); // Start of the line at ball's position
            lineRenderer.SetPosition(1, transform.position + Vector3.up * 10.0f); // End of the line above the ball
        }

        if (isGrappling)
        {
            rb.velocity = new Vector2(rb.velocity.x, grappleForce); // Apply upward force
            lineRenderer.SetPosition(0, transform.position); // Update start of the line to follow the ball
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            isGrappling = false;
            lineRenderer.positionCount = 0; // Remove the line
        }
    }

    // Check if the ball has landed after jumping
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Landed: " + Time.time);
        }
    }
}

// Making small temp changes
