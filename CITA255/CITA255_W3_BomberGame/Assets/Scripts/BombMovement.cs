using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    public float BombFallingSpeedY = -2;
    public float BombFallingSpeedX = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the current  position of the bomber
        UnityEngine.Vector3 BombPos = transform.position;

        //change the vector position
        BombPos.y += BombFallingSpeedY * Time.deltaTime;
        BombPos.x += BombFallingSpeedX * Time.deltaTime;

        transform.position = BombPos;     // Move the bomber to the new position
    }

    public void OnCollisionEnter(Collision collision)
    {
        // if the collision is between bomb and game jobect with the tag enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //destroy the enemy
            Destroy(collision.gameObject);
            
            GameManager.instance.score++;
            Debug.Log("Score: " + GameManager.instance.score);

            //destroy the bomb  / itself
            Destroy(gameObject);
        }
    }
}
