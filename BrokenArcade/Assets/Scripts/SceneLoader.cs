using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }  // Singleton instance

    private int winCount = 0;  // Keeps track of the number of wins

    // Ensure the singleton instance exists
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // Set the instance if it's null
            DontDestroyOnLoad(gameObject);  // Keep this GameObject between scene loads
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
    }

    // Call this method when you win a game
    public void OnWin()
    {
        winCount++;  // Increment the win count

        if (winCount == 1)
        {
            int screenIndex = Random.Range(1, 4); 
            LoadScreen(screenIndex);
        }
        else if (winCount == 2)
        {
            int remainingScreen = GetRemainingScreen();
            LoadScreen(remainingScreen);
        }
        else if (winCount == 3)
        {
            SceneManager.LoadScene("winScene");
        }
    }

    public void OnLose()
    {
        int screenIndex = Random.Range(1, 4); 
        LoadScreen(screenIndex);
    }

    private void LoadScreen(int screenIndex)
    {
        string sceneName = "Screen" + screenIndex;
        SceneManager.LoadScene(sceneName);
    }

    private int GetRemainingScreen()
    {
        // Get the screen indices that have already been visited
        System.Collections.Generic.List<int> availableScreens = new System.Collections.Generic.List<int> { 1, 2, 3 };
        if (winCount > 1)
        {
            // Remove the screen that was already visited
            int previousScreen = Random.Range(1, 4);
            availableScreens.Remove(previousScreen);
        }
        return availableScreens[0]; 
    }
}
