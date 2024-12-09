using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    public Catcher catcherScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is a bomb or a ball
        if (collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Ball"))
        {
            catcherScript.UpdateScore(-2);
            Destroy(collision.gameObject);
        }
    }
}
