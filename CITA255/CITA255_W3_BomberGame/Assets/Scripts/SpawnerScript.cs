using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{

    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, 0.5F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(EnemyPrefab);
        newEnemy.transform.position = new Vector3(
            Random.Range(-1f, 1f), //Random x value between 1 and -1
            Random.Range(-1f, 1f), //Random y value between 1 and -1
            0);                     // z has to be 0
            
    }
}
