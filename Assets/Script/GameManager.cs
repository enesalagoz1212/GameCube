using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOn;
    public GameStatus gameStatus;
    
    public LevelManager levelManager;
    public UiManager uiManager;

    public MyCube myCube;
    
    public int currentLevelNumber;

    private void Start()
    {
        gameStatus = GameStatus.Start;
        currentLevelNumber = 0;
        OnLevelLoad();
    }

    public void OnLevelLoad()
    {
        levelManager.CreateLevel();
        isGameOn = true;
        gameStatus = GameStatus.GameOn;
    }

    public void OnLevelCompleted()
    {
        isGameOn = false;
        
        currentLevelNumber++;

        Invoke("OnLevelReset", 1f);

        gameStatus = GameStatus.End;
    }

    public void OnLevelFail()
    {
        isGameOn = false;
        Invoke("OnLevelReset", 1f);

        gameStatus = GameStatus.End;
    }
    
    public void OnLevelReset()
    {
        // Reset Cube
        OnLevelLoad();
        myCube.OnLevelReset();
    }
}

public enum GameStatus
{
    Start,
    GameOn,
    End,
}