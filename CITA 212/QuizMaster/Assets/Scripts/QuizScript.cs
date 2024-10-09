using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerbuttons;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerbuttons.Length; i++)
        // this will look through the cildren of answer buttons and find the first textmeshpro component that it can
        // then it will change the text of that button to answer of our stored question
        {
        TextMeshProUGUI buttonText = answerbuttons[i].GetComponentInChildren<TextMeshProUGUI>();        
        buttonText.text = question.GetAnswer(i);
        }
    }
}
