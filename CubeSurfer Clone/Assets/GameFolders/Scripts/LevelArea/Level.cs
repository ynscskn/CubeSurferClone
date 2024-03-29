using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject Roads;
    public GameObject FinalRoad;

    [HideInInspector] public Path[] Paths;

    private void Awake()
    {

        M_Observer.OnGameCreate += GameCreate;
        M_Observer.OnGameStart += GameStart;
        M_Observer.OnGameReady += GameReady;
        M_Observer.OnGamePause += GamePause;
        M_Observer.OnGameContinue += GameContinue;
        M_Observer.OnGameFail += GameFail;
        M_Observer.OnGameComplete += GameComplete;
        M_Observer.OnGameRetry += GameRetry;
        M_Observer.OnGameNextLevel += GameNextLevel;
    }
    private void OnDestroy()
    {
        M_Observer.OnGameCreate -= GameCreate;
        M_Observer.OnGameStart -= GameStart;
        M_Observer.OnGameReady -= GameReady;
        M_Observer.OnGamePause -= GamePause;
        M_Observer.OnGameContinue -= GameContinue;
        M_Observer.OnGameFail -= GameFail;
        M_Observer.OnGameComplete -= GameComplete;
        M_Observer.OnGameRetry -= GameRetry;
        M_Observer.OnGameNextLevel -= GameNextLevel;
    }

    void CreatePath()
    {
        
        Paths = Roads.GetComponentsInChildren<Path>();


        for (int i = 0; i < Paths.Length; i++)
        {
            for (int j = 0; j < Paths[i].PathTransformsArray.Length; j++)
            {
                M_Game.I.RoadPath.Add(Paths[i].PathTransformsArray[j].position);

            }
        }
    }

    private void GameCreate()
    {
        CreatePath();
    }

    private void GameStart()
    {
        print("GameStart");
    }
    private void GameReady()
    {
        print("GameReady");
    }
    private void GamePause()
    {
        print("GamePause");
    }
    private void GameContinue()
    {
        print("GameContinue");
    }
    private void GameFail()
    {
        print("GameFail");
    }
    private void GameComplete()
    {
        print("GameComplete");
    }
    private void GameRetry()
    {
        print("GameRetry");
    }
    private void GameNextLevel()
    {
        print("GameNextLevel");
    }
}
