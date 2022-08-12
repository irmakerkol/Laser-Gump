using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI remainingToHighScore;

    public float score; 
    
    public float highScore;

    public float pointsPerSecond;
    public bool scoreIncreasing;

    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore", highScore);
        }
        else highScore = 0f;
    }
   

    // Update is called once per frame
    void Update()
    {
        increaseScore();
        setHighScore();
        setTexts();
    }
    

    public void increaseScore()
    {
        if (scoreIncreasing)
        {
            score += pointsPerSecond * Time.deltaTime;
        }
    }

    public void setHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);

        }
    }

    public void setTexts()
    {
        scoreText.text = "" + Mathf.Round(score);
        if(highScore > score){
            remainingToHighScore.text = Mathf.Round(highScore - score) + " Remaining to HS";
        }else {
            remainingToHighScore.text = "New High Score!";
        }
    }


}
