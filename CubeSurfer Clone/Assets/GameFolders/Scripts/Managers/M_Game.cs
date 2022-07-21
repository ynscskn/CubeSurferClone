using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class M_Game : MonoBehaviour
{
    public GameObject ChibiGuyPrefab;

    public Transform PlayerConteiner;
    public Transform PlayerSpawn;
    public Transform CubeConteiner;
    public CameraMultiTarget CameraMultiTarget;

    [HideInInspector] public GameObject CurrentPlayer;
    [HideInInspector] public List<Vector3> RoadPath;
    [HideInInspector] public List<Vector3> FinalPath;
    [HideInInspector] public bool IsPlaying = false;

    List<Tween> playerTweenList;


    private void Awake()
    {
        II = this;
        RoadPath = new List<Vector3>();
        FinalPath = new List<Vector3>();
        playerTweenList = new List<Tween>();

        M_Observer.OnGameCreate += GameCreate;
        M_Observer.OnGameStart += GameStart;
        M_Observer.OnGameFail += GameFail;
    }

    private void OnDestroy()
    {
        M_Observer.OnGameCreate -= GameCreate;
        M_Observer.OnGameStart -= GameStart;
        M_Observer.OnGameFail -= GameFail;
    }

    private void GameStart()
    {
        IsPlaying = true;
    }

    private void GameCreate()
    {
        CurrentPlayer = Instantiate(ChibiGuyPrefab, PlayerSpawn);
    }

    private void GameFail()
    {
        IsPlaying = false;
    }

    private void OnEnable()
    {
        FingerGestures.OnFingerDragMove += FingerGestures_OnFingerDragMove;
    }
    private void OnDisable()
    {
        FingerGestures.OnFingerDragMove -= FingerGestures_OnFingerDragMove;
    }

    float playerPosX;
    float screenDeltaX;

    private void FingerGestures_OnFingerDragMove(int fingerIndex, Vector2 fingerPos, Vector2 delta)
    {
        if (fingerIndex != 0) return;

        screenDeltaX = delta.x * Screen.width / 1080;

        if (screenDeltaX == 0 || !IsPlaying) return;

        playerPosX += 0.05f * screenDeltaX;

        playerPosX = Mathf.Clamp(playerPosX, -4, 4);

        PlayerSpawn.transform.localPosition = new Vector3(playerPosX, 0, 0);
    }

    public List<Tween> ObjectTransforms(float delayTime)
    {
        playerTweenList.Clear();
        int posY = 0;
        for (int i = 0; i < CubeConteiner.transform.childCount; i++)
        {
            Tween _cubeTween = CubeConteiner.transform.GetChild(i).transform.DOLocalMove(new Vector3(0, posY, 0), 20).SetDelay(delayTime).SetSpeedBased();
            playerTweenList.Add(_cubeTween);
            posY += 2;
        }
        Tween _playerTween = CurrentPlayer.transform.DOLocalMove(new Vector3(0, posY, 0), 16).SetDelay(delayTime).SetSpeedBased();
        playerTweenList.Add(_playerTween);
        SetCamera();
        return playerTweenList;
    }

    int _childCount;
    Tween _camTween;
    public void SetCamera()
    {
        _childCount = CubeConteiner.childCount;

        if (_childCount > 10) return;

        else if (_childCount > 5)
        {
            if (_camTween != null) _camTween.Kill();
            _camTween = DOTween.To(() => CameraMultiTarget.PaddingDown, x => CameraMultiTarget.PaddingDown = x, _childCount * -1, 1f);//.SetEase(Ease.OutExpo);
        }
        else if (_childCount <= 5)
        {
            if (CameraMultiTarget.PaddingDown != 0)
            {
                DOTween.To(() => CameraMultiTarget.PaddingDown, x => CameraMultiTarget.PaddingDown = x, 0, 1f);//.SetEase(Ease.OutExpo);// CameraMultiTarget.PaddingDown = 0;
            }
        }
    }
    public static M_Game II;

    public static M_Game I
    {
        get
        {
            if (II == null)
            {
                GameObject _g = GameObject.Find("M_Game");
                if (_g != null)
                {
                    II = _g.GetComponent<M_Game>();
                }
            }

            return II;
        }
    }

}
