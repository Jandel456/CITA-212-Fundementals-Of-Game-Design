using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 15f;
    [SerializeField] float timeToShowCorrectAnswer = 5f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;
    
    float timerValue;   // floats start at 0 by default :)

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
        Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
