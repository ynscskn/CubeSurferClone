using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerContainer : MonoBehaviour
{
    Tween MoveTween;
    private void Awake()
    {
        M_Observer.OnGameStart += GameStart;
    }
    private void OnDestroy()
    {
        M_Observer.OnGameStart -= GameStart;

    }

    void GameStart()
    {
        MoveTween = this.transform.DOPath(M_Game.I.RoadPath.ToArray(), 20).SetLookAt(0.05f).SetEase(Ease.Linear).SetSpeedBased().SetLoops(0);
    }

    
}
