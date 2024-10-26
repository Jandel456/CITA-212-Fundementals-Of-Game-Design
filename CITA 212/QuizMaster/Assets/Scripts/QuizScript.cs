using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class QuizScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerbuttons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

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

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if(index == question.GetCorretAnswerIndex())
        {
            questionText.text = "Correct!"; // "Correct!" for now is a placeholder, we might want to add more details like why its correct
            buttonImage = answerbuttons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorretAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry the correct answer was;\n" + correctAnswer;

            buttonImage = answerbuttons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
