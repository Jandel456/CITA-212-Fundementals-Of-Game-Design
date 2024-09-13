using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
//using System.IO         // don't forget to add this for the file papth stuff

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;


    const string FILE_DIR = "/Data/";
    const string FILE_NAME = "Dialogue.txt";
    string FILE_PATH; 
    
    string[] dialogueArray;

    int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;

        if (File.Exists(FILE_PATH))
        {

            // Debug.Log("File exists, yay!");          // No need for this anymore, It works! SO we're going to comment it out.
            dialogueArray = File.ReadAllLines(FILE_PATH);
        }
        else
        {
            Debug.Log("Something Is wrong with the path.");
        }

        currentLine = 1;
        dialogueText.text = dialogueArray[currentLine];
        // DebugArray();        // commenting out this debug array because we know for sure it works now, so the void thing beneath this is pretty much useless.
    }

    public void ClickNextButton()
    {
        if (currentLine < dialogueArray.Length - 1)
        {
            currentLine++;
            dialogueText.text = dialogueArray[currentLine];
        }
    }

    void DebugArray()
    {
        string message = " ";

        // //start with line 0 for the for loop
        // for(int i = 0; i < dialogueArray.Length; i++)
        // {
        // message += dialogueArray[i] + "\n";
        // }

        // //start with line 0 with for each loop
        // foreach(string line in dialogueArray)
        // {
        //     message += line + "\n";
        // }

        // start with line 1 with for loop

        for (int i = 1; i < dialogueArray.Length; i++)
        {
            message += dialogueArray[i] + "\n";
        }

        Debug.Log(message);
    }

}
