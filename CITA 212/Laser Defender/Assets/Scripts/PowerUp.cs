using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // This will be called when the player collides with the power-up
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePowerUp();

            Destroy(gameObject);
        }
    }

    private void ActivatePowerUp()
    {
        //Shooter.baseFiringRate = 0.2;

        Debug.Log("I tried");
    }
}