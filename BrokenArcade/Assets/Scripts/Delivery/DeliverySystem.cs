using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{    SpriteRenderer spriteRenderer;


    bool hasPackaage;
    [SerializeField] float destroyDelay = 0.5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackaage)
        {
            Debug.Log("I picked up the package"); 
            hasPackaage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Customer" && hasPackaage)
        {
            Debug.Log("Another Happy Customer");
            hasPackaage = false;
            StartCoroutine(WaitTwoSeconds());
            /// PUT WIN IN HERE.


        }   
        IEnumerator WaitTwoSeconds()
        {
            yield return new WaitForSeconds(2);
            Debug.Log("3 seconds have passed!");
        }
    }

}
