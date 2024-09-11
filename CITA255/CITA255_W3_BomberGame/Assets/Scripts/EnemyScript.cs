using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public float EnemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpeed = Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 EnemyPos = transform.position;
        EnemyPos.x += EnemySpeed * Time.deltaTime;
        transform.position =EnemyPos;
    }

    void SpawnEnemy()
    {
        
    }
}
