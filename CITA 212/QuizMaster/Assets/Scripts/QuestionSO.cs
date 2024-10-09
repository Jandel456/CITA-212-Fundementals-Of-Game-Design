using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]     //allows us to change how many lines of text can fit in the serialized field to make it easier to edit questions in the future, the user wont see it, only the devs will.
    [SerializeField] string question = "Enter new question text here";

    public string GetQuestion()
    {
        return question;
    }
}
