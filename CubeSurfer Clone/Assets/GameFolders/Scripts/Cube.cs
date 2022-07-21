using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{

    List<Tween> posTweenList;

    private void Awake()
    {
        M_Observer.OnGameFail += GameFail;
    }

    private void OnDestroy()
    {
        M_Observer.OnGameFail -= GameFail;

    }
    private void OnTriggerEnter(Collider other)
    {
        posTweenList = new List<Tween>();

        float delayTime;
        if (other.CompareTag("Obstacle"))
        {
            delayTime = 0.25f;

            transform.SetParent(other.transform);

            posTweenList = M_Game.I.ObjectTransforms(delayTime);


        }
        if (other.CompareTag("Lava"))
        {
            delayTime = 0.15f;

            transform.SetParent(other.transform);

            posTweenList = M_Game.I.ObjectTransforms(delayTime);

        }

    }


    void GameFail()
    {
        if (posTweenList != null)
        {
            for (int i = 0; i < posTweenList.Count; i++)
            {
                posTweenList[i].Kill();
            }

        }

    }
}
