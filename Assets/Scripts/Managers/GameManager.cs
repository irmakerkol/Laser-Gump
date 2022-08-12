using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public bool gameStarted;
    [SerializeField] private AudioClip music;


    void Start()
    {
        gameStarted = false;
    }

    public void startGame(){
        gameStarted = true;
        ScoreManager.instance.scoreIncreasing = true;
        AudioManager.instance.playSound(music);
    }

    public void endGame(){
        gameStarted = false;
        ScoreManager.instance.score = 0;
        ScoreManager.instance.scoreIncreasing = false;
    }

}