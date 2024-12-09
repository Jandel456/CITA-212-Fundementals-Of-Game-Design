using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RandomSceneLoader : MonoBehaviour
{
    public static RandomSceneLoader Instance;

    private List<int> remainingScenes; // List of scenes that haven't been visited

    void Awake()
    {
        // Singleton pattern to ensure only one instance persists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            InitializeSceneList();
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void InitializeSceneList()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        remainingScenes = new List<int>();

        for (int i = 0; i < sceneCount; i++)
        {
            remainingScenes.Add(i);
        }
    }

    public void LoadRandomScene()
    {
        if (remainingScenes.Count == 0)
        {
            Debug.Log("All scenes have been visited! Reloading the scene list.");
            InitializeSceneList();
        }

        // Select a random scene from the remaining ones
        int randomIndex = Random.Range(0, remainingScenes.Count);
        int sceneToLoad = remainingScenes[randomIndex];

        // Remove the selected scene from the list
        remainingScenes.RemoveAt(randomIndex);

        // Load the selected scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
