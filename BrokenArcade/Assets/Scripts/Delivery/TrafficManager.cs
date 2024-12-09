using UnityEngine;

public class TrafficManager2D : MonoBehaviour
{
    // Public fields for configuring the traffic light
    public bool startWithRed = true; 
    public float redDuration = 3f;  // Duration for red light
    public float greenDuration = 3f; // Duration for green light
    public GameObject collisionBox; 
    private bool isRed;             // Current state of the traffic light
    private float timer;
    public Sprite Red;
    public Sprite Green;
    public GameObject TrafficSprite; // the target for changing the sprite of the fighter


    void Start()
    {
        isRed = startWithRed;
        timer = isRed ? redDuration : greenDuration; // ? checks if it is nullable, very interesting

        UpdateCollisionBox();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isRed = !isRed;
            timer = isRed ? redDuration : greenDuration; // Reset timer

            UpdateCollisionBox();
        }
    }

    private void UpdateCollisionBox()
    {
        if (collisionBox != null)
        {
            collisionBox.SetActive(isRed);

        }

        if (TrafficSprite != null)
        {
            SpriteRenderer spriteRenderer = TrafficSprite.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = isRed ? Red : Green;
            }
        }
    }
}
