using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public bool gameStarted;

    void Start()
    {
        gameStarted = false;
    }

    public void startGame(){
        gameStarted = true;
        ScoreManager.instance.scoreIncreasing = true;
    }

    public void endGame(){
        gameStarted = false;
        ScoreManager.instance.score = 0;
        ScoreManager.instance.scoreIncreasing = false;
    }

}