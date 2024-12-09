using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Required for accessing the Text UI element

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;  
    private float timeRemaining = 30f;  
    private bool timerRunning = false;  

    void Start()
    {
        timerRunning = true;  
    }

    void Update()
    {

        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                GameController.Instance.OnLose();


                timerRunning = false;  // Stop the timer when it reaches 0
            }

            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        // Display the remaining time as a whole number
        timerText.text = Mathf.Ceil(timeRemaining).ToString();  
    }

    // Optionally, you can call this method to reset the timer (e.g., when restarting the game)
    public void ResetTimer()
    {
        timeRemaining = 30f;
        timerRunning = true;
    }
}
