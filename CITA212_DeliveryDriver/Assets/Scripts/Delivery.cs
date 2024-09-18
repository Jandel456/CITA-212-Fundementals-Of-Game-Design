using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class Collision : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    SpriteRenderer spriteRenderer;


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
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Customer" && hasPackaage)
        {
            Debug.Log("Another Happy Customer");
            hasPackaage = false;
            spriteRenderer.color = noPackageColor;

        }   
    }

}
