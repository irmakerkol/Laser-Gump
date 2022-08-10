using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshPro remainingToHighScore;

    public float score;
    public float highScore;

    public float pointsPerSecond;
    public bool scoreIncreasing;

   

    // Update is called once per frame
    void Update()
    {
        increaseScore();
        setHighScore();
        setTexts();
    }

    void increaseScore()
    {
        if (scoreIncreasing)
        {
            score += pointsPerSecond * Time.deltaTime;
        }
    }

    void setHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    void setTexts()
    {
        scoreText.text = "" + Mathf.Round(score);
        remainingToHighScore.text = Mathf.Round(highScore - score) + "Remaining to HS";
    }


}
