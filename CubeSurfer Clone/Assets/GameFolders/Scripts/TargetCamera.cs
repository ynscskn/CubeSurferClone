using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    public GameObject[] CameraTargets;
    public CameraMultiTarget cameraMultiTarget;

    private void Awake()
    {

        M_Observer.OnGameStart += GameStart;

        M_Observer.OnGameFail += GameFail;
    }

    private void OnDestroy()
    {
        M_Observer.OnGameStart -= GameStart;

        M_Observer.OnGameFail -= GameFail;
    }

    private void GameStart()
    {
        cameraMultiTarget.SetTargets(CameraTargets);
    }

    private void GameFail()
    {
    }

}
