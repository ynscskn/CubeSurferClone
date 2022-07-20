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

    private void OnTriggerEnter(Collider other)
    {
        //print("123123");
        //if (other.transform.tag == "Cube")
        //{
        //    GameObject currentCube = other.gameObject;
        //    currentCube.transform.SetParent(Cubes);
        //    currentCube.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.OutSine);
        //    //currentCube.transform.localPosition = (Cubes.transform.childCount - 1) * new Vector3(0, 2, 0);
        //    M_Game.I.CurrentPlayer.transform.DOLocalMove(Cubes.transform.childCount * new Vector3(0, 2, 0), 0.5f).SetEase(Ease.OutExpo);
        //}
    }

}
