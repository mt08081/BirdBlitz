using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeController : MonoBehaviour
{
    public Slider chargeBar;
    public float chargeSpeed = 1.0f;
    public float maxCharge = 100.0f;
    private float currentCharge = 0.0f;
    private bool isCharging = false;
    private bool isPaused = false; // Add this flag
    private Rigidbody2D ballRb;

    private bool isGrounded = false;

    public void SetGrounded(bool grounded)
    {
        this.isGrounded = grounded;
    }

    void Start()
    {
        ballRb = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        chargeBar.maxValue = maxCharge;
        chargeBar.value = 0;
    }

    void Update()
    {
        if (isPaused) return; // If the game is paused, do nothing

        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
        }

        if (Input.GetMouseButtonUp(0) && isGrounded)
        {
            isCharging = false;
            ApplyForce();
            currentCharge = 0;
            chargeBar.value = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;
            currentCharge = 0;
            chargeBar.value = 0;
        }

        if (isCharging)
        {
            Charge();
        }
    }

    public void PauseGame() // Call this function when the pause/menu button is pressed
    {
        isPaused = true;
        isCharging = false; // Stop charging when the game is paused
        chargeBar.value = 0;
    }

    public void ResumeGame() // Call this function when the game is resumed
    {
        isPaused = false;
        chargeBar.value = 0;
    }

    void Charge()
    {
        if (currentCharge < maxCharge)
        {
            currentCharge += chargeSpeed * Time.deltaTime;
            chargeBar.value = currentCharge;
        }
    }

    void ApplyForce()
    {
        float force = currentCharge;
        if (force < 6.0f)
        {
            force = 6.0f;
        }

        ballRb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        Debug.Log(force);
    }
}