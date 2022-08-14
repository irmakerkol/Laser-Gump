using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public bool gameStarted;
    [SerializeField] private AudioClip music;

    void Start()
    {
        gameStarted = false;
        CharacterAnimatorManager.instance.stopRunning();

    }

    public void startGame(){
        CharacterAnimatorManager.instance.run();
        gameStarted = true;
        ScoreManager.instance.scoreIncreasing = true;
        AudioManager.instance.playSound(music);
    }

    public void endGame(){
        CharacterAnimatorManager.instance.stopRunning();
        gameStarted = false;
        ScoreManager.instance.score = 0;
        ScoreManager.instance.scoreIncreasing = false;
    }

}