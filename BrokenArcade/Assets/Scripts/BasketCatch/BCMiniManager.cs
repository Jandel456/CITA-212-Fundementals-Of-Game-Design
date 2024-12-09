using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BCMiniManager : MonoBehaviour
{
    public Transform spawner;
    public GameObject ballPrefab;
    public GameObject bombPrefab;
    public Transform basket;
    public TextMeshProUGUI heartsText;

    public float spawnerSpeed = 5f;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;
    public int maxHearts = 3;

    private int currentHearts;
    private float spawnerDirection = 1f;
    private float screenLimitX;

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();

        screenLimitX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - 1;
        StartCoroutine(SpawnerMovement());
        StartCoroutine(SpawnObjects());
    }

    void UpdateHeartsUI()
    {
        heartsText.text = "Hearts: " + currentHearts;
    }

    void LoseHeart()
    {
        currentHearts--;
        UpdateHeartsUI();

        if (currentHearts <= 0)
        {
            Debug.Log("Game Over");
            // Handle game over logic here (e.g., reload scene, show game over UI, etc.)
        }
    }

    IEnumerator SpawnerMovement()
    {
        while (true)
        {
            spawner.position += Vector3.right * spawnerDirection * spawnerSpeed * Time.deltaTime;

            if (spawner.position.x > screenLimitX || spawner.position.x < -screenLimitX)
            {
                spawnerDirection *= -1;
            }

            yield return null;
        }
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));

            GameObject spawnedObject;
            if (Random.value < 0.8f) // 80% chance to spawn a ball
            {
                spawnedObject = Instantiate(ballPrefab, spawner.position, Quaternion.identity);
            }
            else // 20% chance to spawn a bomb
            {
                spawnedObject = Instantiate(bombPrefab, spawner.position, Quaternion.identity);
            }

            spawnedObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            LoseHeart();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            LoseHeart();
        }
    }
}