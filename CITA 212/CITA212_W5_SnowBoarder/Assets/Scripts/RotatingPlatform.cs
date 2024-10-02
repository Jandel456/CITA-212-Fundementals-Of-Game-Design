using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    [SerializeField] float rotation = 10f;
    [SerializeField] float LoadDelay = 0.4f;


    Rigidbody2D rb2d;
    private Quaternion originalPos;
    bool contact = false;


    void Start()
    {
        originalPos = transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        RotateBox();
    }

    void Update()
    {
        if (contact == false)
        {
            RotateBox();
        }
    }

    void RotateBox()
    {
        rb2d.AddTorque(rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !contact)
        {
            contact = true;
            Invoke("BoxReset", LoadDelay);
        }
    }
    
    void BoxReset()
    {
        transform.rotation = originalPos;
        rb2d.angularVelocity = 0f;
        contact = false;
    }

}
