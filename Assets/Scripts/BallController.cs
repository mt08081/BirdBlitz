/*

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

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    public float rotationSpeed = 360.0f;
    private Rigidbody2D rb;
    private UIManager uiManager;
    private GameController gameController;
    private Animator animator;

    private bool isInvincible = false; // Track the invincibility state

    private bool isDoubleJump = false; // Track the Double Jump state

    private ChargeController chargeController;

    private bool isGrounded = false;

    public Transform groundFeeler; // Assign the transparent circle object in the Inspector
    public float groundDetectionRadius = 0.1f; // Adjust this value to fine-tune detection

    private Collider2D[] detectedColliders = new Collider2D[10];
    public LayerMask groundLayerMask; // Assign the "Ground" layer in the Inspector
    public  Money moneyScript2;
    int money3;

    void Start()
    {

       
        rb = GetComponent<Rigidbody2D>();
        uiManager = FindObjectOfType<UIManager>();
        gameController = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();
        chargeController = GameObject.FindObjectOfType<ChargeController>();
         if (moneyScript2 == null)
        {
            moneyScript2 = FindObjectOfType<Money>();
        }
        money3= moneyScript2.GetMoney();
        Debug.Log("MOENY ON LVL IS " + money3);
    }

    void Update()
    {
       
        
        RollForward();

        bool isGrounded = IsGrounded();
        chargeController.SetGrounded(isGrounded);
        //OnTriggerEnter2D(other);

        // Get the y value of the object
        Debug.Log(transform.position.y);
        Debug.Log( "before  MOENY ON LVL UPD IS " );
        money3= PlayerPrefs.GetInt("Money", 1000);
        Debug.Log("MOENY ON LVL UPD IS " );
        Debug.Log(money3);
    }

    bool IsGrounded()
    {
        int detectedColliderCount = Physics2D.OverlapCircleNonAlloc(groundFeeler.position, groundDetectionRadius, detectedColliders, groundLayerMask);
        return detectedColliderCount > 0;
    }

    void RollForward()
    {
        // Rotate the ball to give the rolling effect
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
            uiManager.IncrementCrystalCount();
            // moneyScript2.addMoney(30);
            Debug.Log("Money is on a level upon crystal" + moneyScript2.money);

        }
        else if (other.gameObject.CompareTag("Spike"))
        {
            if (!isInvincible)
            {
                gameController.TriggerLoss();
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {
                gameController.TriggerLoss();
            }
        }
        else if (other.gameObject.CompareTag("Portal"))
        {
            Debug.Log(" TOTAL CRYSTAL ARE "+ uiManager.crystalCount);
            gameController.TriggerWin();
            Debug.Log(" TOTAL CRYSTAL ARE "+ uiManager.crystalCount);

            moneyScript2.addMoney(uiManager.crystalCount);

        }
        else if (other.gameObject.CompareTag("Powerup_G"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ActivateInvincibility());
        }
        else if (other.gameObject.CompareTag("Powerup_J"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ActivateDoubleJump());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            chargeController.isGrounded2 = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            chargeController.isGrounded2 = false;
        }
    }

    IEnumerator ActivateDoubleJump()
    {
        isDoubleJump = true;
        chargeController.IncrementMaxJumps();

        yield return new WaitForSeconds(3.5f);

        isDoubleJump = false;
        chargeController.DecrementMaxJumps();

    }

    IEnumerator ActivateInvincibility()
    {
        isInvincible = true;
        animator.SetBool("isInvincible", true);

        yield return new WaitForSeconds(3.5f); // Duration of the invincibility

        isInvincible = false;
        animator.SetBool("isInvincible", false);
    }
    
}


