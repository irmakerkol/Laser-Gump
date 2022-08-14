using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField]  GameObject obstacle1Level1, obstacle2Level1;
    [SerializeField]  GameObject obstacle1Level2, obstacle2Level2, obstacle3Level2;

    [SerializeField] GameObject laserLevel0, laserLevel1;
    public int level;

    private void Start()
    {
        level = 0;
        obstacle1Level2.SetActive(false);
        obstacle2Level2.SetActive(false);
        obstacle3Level2.SetActive(false);
        laserLevel1.SetActive(false);
    }

    public void levelUp(){
        level = 1;
        laserLevel1.SetActive(true);
        laserLevel0.SetActive(false);
        obstacle1Level1.SetActive(false);
        obstacle2Level1.SetActive(false);
        obstacle1Level2.SetActive(true);
        obstacle2Level2.SetActive(true);
        obstacle3Level2.SetActive(true);
    }

}
