using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using System;
using Random = UnityEngine.Random;

public class QuizScript : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerbuttons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if(index == currentQuestion.GetCorretAnswerIndex())
        {
            questionText.text = "Correct!"; // "Correct!" for now is a placeholder, we might want to add more details like why its correct
            buttonImage = answerbuttons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorretAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry the correct answer was;\n" + correctAnswer;

            buttonImage = answerbuttons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for(int i = 0; i < answerbuttons.Length; i++)
        // this will look through the cildren of answer buttons and find the first textmeshpro component that it can
        // then it will change the text of that button to answer of our stored question
        {
            TextMeshProUGUI buttonText = answerbuttons[i].GetComponentInChildren<TextMeshProUGUI>();        
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerbuttons.Length; i++)
        {
            Button button = answerbuttons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerbuttons.Length; i++)
        {
            Image buttonImage = answerbuttons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

}
