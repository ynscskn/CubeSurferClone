using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerContainer : MonoBehaviour
{
    Tween MoveTween;
    private void Awake()
    {
        M_Observer.OnGameStart += GameStart;
        M_Observer.OnGameFail += GameFail;
        M_Observer.OnStartFinal += StartFinal;


    }
    private void OnDestroy()
    {
        M_Observer.OnGameStart -= GameStart;
        M_Observer.OnGameFail -= GameFail;
        M_Observer.OnStartFinal -= StartFinal;

    }
    void GameStart()
    {
        MoveTween = this.transform.DOPath(M_Game.I.RoadPath.ToArray(), 20).SetLookAt(0.05f).SetEase(Ease.Linear).SetSpeedBased().SetLoops(0);
    }
    private void GameFail()
    {
        MoveTween.Kill();
    }
    private void StartFinal()
    {
        this.transform.DOPath(M_Game.I.FinalPath.ToArray(), 30).SetLookAt(0.05f).SetEase(Ease.Linear).SetSpeedBased().SetLoops(0);
    }
}
