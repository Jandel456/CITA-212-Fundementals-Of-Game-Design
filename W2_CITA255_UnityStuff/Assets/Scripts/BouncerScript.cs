using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BouncerScript : MonoBehaviour
{
    private int age;
    public TextMeshProUGUI ageText, bouncerText;

    //The Lines that bouncer says to us
    string welcomeString, entryString, denyString;

    // Start is called before the first frame update
    void Start()    
    {
        age = Random.Range(18, 26);
        Debug.Log("What is my age? "+ age);

        //initialize ageText
        ageText.text = "My age: " + age;

        //initialize and show ageText on screen
        welcomeString = "Welcome! ID please?";
        entryString = "Have fun! Dont' drink too much!";
        denyString = "You are too young to enter, kid.";

        bouncerText.text = welcomeString;
    }

    public void ClickNewAgeButton()
    {
        Debug.Log("I am clicking on the new age button!");
        age = Random.Range(18, 26);                  // randomnize the age number again
        ageText.text = "My age:  " + age;            // updating the age on screen

        // every time I click on the new age button
        // reset the bouncer text back to the welcome string
        bouncerText.text = welcomeString;
    }

    public void ClickShowIDButton()
    {
        Debug.Log("I am clicking on the show ID button!");

        if (age < 21)
        {
            bouncerText.text = denyString;
        }
        else
        {
            bouncerText.text = entryString;
        }
    }
}
