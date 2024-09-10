using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Booting Up, Beep Boop");
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.D))
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        
    }
    else if (Input.GetKey(KeyCode.A))
    {
        transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        
    }

    else if (Input.GetKey(KeyCode.W))   
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

    }
    else if (Input.GetKey(KeyCode.S))
    {
        transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

    }
    }
}
