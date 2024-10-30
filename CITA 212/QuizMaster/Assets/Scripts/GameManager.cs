using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    QuizScript quizScript;
    Endscreen endscreen;

    void Awake()
    {
        quizScript = FindObjectOfType<QuizScript>();
        endscreen = FindObjectOfType<Endscreen>();
    }

    void Start()
    {
        quizScript.gameObject.SetActive(true);
        endscreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quizScript.isComplete)
        {
            quizScript.gameObject.SetActive(false);
            endscreen.gameObject.SetActive(true);
            endscreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
