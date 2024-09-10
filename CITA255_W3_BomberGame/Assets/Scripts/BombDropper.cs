using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();

        }
    }

    void DropBomb()
    {
        //generate a new bomb based on our bomb prefab
        GameObject newBomb = Instantiate(bombPrefab);
        // newBomb.transform.position = transform.position;
        newBomb.transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y - 0.1f, 0);
    }
}
