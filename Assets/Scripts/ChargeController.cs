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
    private Rigidbody2D ballRb;
    //private float minValue;

    void Start()
    {
        ballRb = GameObject.Find("Ball").GetComponent<Rigidbody2D>(); // Adjust the name if necessary
        chargeBar.maxValue = maxCharge;
        chargeBar.value = 0;
        //minValue = chargeBar.minValue;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;
            ApplyForce();
            currentCharge = 0;
            chargeBar.value = 0;
        }

        if (isCharging)
        {
            Charge();
        }
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
        float force = currentCharge; // Adjust the force calculation as needed
        if (force < 6.0f)
        {
            force = 6.0f;
        }

        ballRb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        Debug.Log(force);
    }
}
