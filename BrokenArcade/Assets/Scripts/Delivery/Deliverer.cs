using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deliverer : MonoBehaviour
{
    [SerializeField] float steerSpeed = 125;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float defaultSpeed = 25f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 50;


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed *Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("You are Boosting");
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You're slow now");
        moveSpeed = slowSpeed;
        StartCoroutine(WaitThreeSeconds());
    }

    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("3 seconds have passed!");
        moveSpeed = defaultSpeed;

    }

}
