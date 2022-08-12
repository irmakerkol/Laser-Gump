using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField]  GameObject obstacle1Level1, obstacle2Level1;
    [SerializeField]  GameObject obstacle1Level2, obstacle2Level2, obstacle3Level2;
    
    public int level;

    private void Start()
    {
        level = 0;
        obstacle1Level2.SetActive(false);
        obstacle2Level2.SetActive(false);
        obstacle3Level2.SetActive(false);
    }

    public void levelUp(){
        level = 1;
        obstacle1Level1.SetActive(false);
        obstacle2Level1.SetActive(false);
        obstacle1Level2.SetActive(true);
        obstacle2Level2.SetActive(true);
        obstacle3Level2.SetActive(true);
    }

}
