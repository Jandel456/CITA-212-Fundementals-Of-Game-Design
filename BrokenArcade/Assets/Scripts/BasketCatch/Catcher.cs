using TMPro;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public float moveSpeed = 20f;
    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * moveSpeed * Time.deltaTime);
        UpdateScoreText();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            score -= 5;
            Debug.Log("Caught Bomb! Score: " + score);
            Destroy(collision.gameObject); 
        }
        else if (collision.CompareTag("Ball"))
        {
            score += 3;
            Debug.Log("Caught Ball! Score: " + score);
            Destroy(collision.gameObject); 
        }

        if (score >= 30)
        {
            Debug.Log("You Win!");
            GameController.Instance.OnWin();

        }

        if (score <= -30)
        {
            Debug.Log("You Lose!");
            HeartManager.Instance.RemoveHeart();
            GameController.Instance.OnLose();


        }
    }
    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        Debug.Log("Score updated! Current Score: " + score);
    }

     private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    
}
