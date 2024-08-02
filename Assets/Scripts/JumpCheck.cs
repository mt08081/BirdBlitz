using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    private ChargeController chargeController;

    void Start()
    {
        chargeController = GameObject.FindObjectOfType<ChargeController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            chargeController.SetGrounded(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            chargeController.SetGrounded(false);
        }
    }
}
