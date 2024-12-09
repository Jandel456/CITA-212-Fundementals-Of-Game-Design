using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2f;
    public float mingrav = 2f;
    public float maxgrav = 10f;
    public float moveSpeed = 3f; 

    private float spawnTimer;
    private Vector2 moveDirection = Vector2.right; 

    void Start()
    {
        spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {

        MoveSpawner();


        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnObject();
            spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void MoveSpawner()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject newObject = Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);

        // Set a random downward speed for the spawned object
        float randomFallSpeed = Random.Range(mingrav, maxgrav); 
        Rigidbody2D rb = newObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = randomFallSpeed / 10f; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boundary"))
        {
            moveDirection = -moveDirection;
        }
    }
}
