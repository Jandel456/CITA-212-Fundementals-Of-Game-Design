using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BomberMovementScript : MonoBehaviour
{
    public float BomberSpeed = -2;         //define and initiate bomber speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the current  position of the bomber
        UnityEngine.Vector3 BomberPos = transform.position;

        //change the vector position
        BomberPos.x += BomberSpeed * Time.deltaTime;

        transform.position = BomberPos;     // Move the bomber to the new position

    }
}
