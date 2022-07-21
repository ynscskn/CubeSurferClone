using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class M_Observer : MonoBehaviour
{
    public static Action OnGameCreate;
    public static Action OnGameReady;
    public static Action OnGameStart;
    public static Action OnGameFail;
    public static Action OnGameComplete;
    public static Action OnGameRetry;
    public static Action OnGameContinue;
    public static Action OnGameNextLevel;
    public static Action OnGamePause;
    public static Action OnGameMainMenu;

    public static Action<int> OnComboEvent;
    public static Action OnGameCompleteAction;
    public static Action OnStartFinal;


    private void Awake()
    {
        Application.targetFrameRate = 120;

        II = this;
        OnGameCreate += GameCreate;
        OnGameReady += GameReady;
        OnGameStart += GameStart;
        OnGameFail += GameFail;
        OnGameComplete += GameComplete;
        OnGameRetry += GameRetry;
        OnGameContinue += GameContinue;
        OnGameNextLevel += GameNextLevel;
        OnGamePause += GamePause;
        OnGameMainMenu += GameMainMenu;
        OnStartFinal += StartFinal;

    }

    private void Start()
    {
        OnGameCreate?.Invoke();
    }

    private void OnDestroy()
    {
        OnGameCreate -= GameCreate;
        OnGameReady -= GameReady;
        OnGameStart -= GameStart;
        OnGameFail -= GameFail;
        OnGameComplete -= GameComplete;
        OnGameRetry -= GameRetry;
        OnGameContinue -= GameContinue;
        OnGameNextLevel -= GameNextLevel;
        OnGamePause -= GamePause;
        OnGameMainMenu -= GameMainMenu;
        OnStartFinal -= StartFinal;


    }

    private void GameMainMenu()
    {
        //print("GameMenu");
    }
    private void StartFinal()
    {
        //print("StartFinal");
    }

    private void GameCreate()
    {
        //print("GameCreate");
    }

    private void GameReady()
    {
        //print("GameReady");
    }

    private void GameStart()
    {
        //print("GameStart");
    }

    private void GamePause()
    {
        //print("GamePause");
    }

    private void GameFail()
    {
        //print("GameFail");
    }

    private void GameComplete()
    {
        //print("GameComplete");
    }

    private void GameRetry()
    {
        //print("GameRetry");
    }

    private void GameContinue()
    {
        //print("GameContinue");
    }

    private void GameNextLevel()
    {
        //print("GameNextLevel");
    }

    public static M_Observer II;

    public static M_Observer I
    {
        get
        {
            if (II == null)
            {
                GameObject _g = GameObject.Find("M_Observer");
                if (_g != null)
                {
                    II = _g.GetComponent<M_Observer>();
                }
            }

            return II;
        }
    }

    //RAYCAST �LE OBJE YAKALAMA.
    //GameObject PickObject(Vector2 screenPos)
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(screenPos);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        return hit.collider.gameObject;
    //    }

    //    return null;
    //}

    // RAYCAST �LE TA�IMA POZ�SYONU.
    //Vector3 GetWorldPos(Vector2 screenPos)
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(screenPos);

    //    // we solve for intersection with y = 0 plane
    //    float t = -ray.origin.z / ray.direction.z;

    //    return ray.GetPoint(t);
    //}

    //#if UNITY_EDITOR

    //    [ContextMenu("RB_ATAMA")]
    //    public void RB_ATAMA()
    //    {
    //        PieceChilds = GetComponentsInChildren<PieceChild>();
    //        UnityEditor.EditorUtility.SetDirty(this);
    //    }

    //#endif


}