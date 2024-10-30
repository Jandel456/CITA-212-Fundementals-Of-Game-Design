using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]     //allows us to change how many lines of text can fit in the serialized field to make it easier to edit questions in the future, the user wont see it, only the devs will.
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string [4];
    [SerializeField] int correctAnswerIndex; 

    public string GetQuestion()
    {
        return question;
    }
    public string GetAnswer(int index)      // this is returning the answer as a string aat the index that we specified
    {
        return answers[index];
    }
    public int GetCorretAnswerIndex()
    {
        return correctAnswerIndex;
    }

}
