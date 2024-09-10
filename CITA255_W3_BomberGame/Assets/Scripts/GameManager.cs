using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;

    public TextMeshProUGUI scoreText;

    //important Singleton concept
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
