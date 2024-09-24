using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreScript : MonoBehaviour
{
    public TextMeshProUGUI highScoreText, currentScoreText;

    List<int> highScoreList = new List<int>();

    string highScoreString, ccurrentScoreString;

    int currentScore = 0;               //private value
    public int CurrentScore 
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            currentScoreText.text = ccurrentScoreString + "\n" + currentScore;
        }
    }

    private void Start() 
    {
        highScoreString = "High Score";
        ccurrentScoreString = "Current Score";

        CurrentScore = 0;

    }

    //saves the 5 hhighest scores
    public void ClickSaveButton()
    {
        if(highScoreList.Count < 5)
        {
            highScoreList.Add(currentScore);
        }

        else
        {
            int lowest = highScoreList.Min();

            if(lowest < currentScore)
            {
                //remove the lowest score
                int index = highScoreList.IndexOf(lowest);      // get the index of lowest
                highScoreList.Remove(highScoreList[index]);     //remove that lowest score


                //add the new crrent score into the high score list

                highScoreList.Add(currentScore);

                Debug.Log("Remove the lowest high score! Add the new current score!");
            }

            else
            {
                Debug.Log("Curent score too low! Not adding it in");
            }
        }

        CurrentScore = 0;           //reset the current score to 0 and update text
        DebugList();

        SortList();

        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        string text = highScoreString;

        foreach(int score in highScoreList)
        {
            text += "\n" + score;
        }

        highScoreText.text = text;
    }

    void SortList()
    {
        highScoreList.Sort();       // sort the scores in ascending order
        highScoreList.Reverse();    // sort the scores again in descending order
        DebugList();
    }

    void DebugList()
    {
        string message = "The current high score list has: ";
        foreach (int score in highScoreList)
        {
            message += score + ", ";
        }
        Debug.Log(message);
    }

    public void ClickMeButton()
    {
        CurrentScore++;
        Debug.Log("Current Score is" + CurrentScore);
    }


}
