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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        M_Observer.OnGameFail -= GameFail;

    }
    private void OnTriggerEnter(Collider other)
    {
        posTweenList = new List<Tween>();

        float delayTime;
        if (other.tag == "Obstacle")
        {
            delayTime = 0.25f;

            transform.SetParent(other.transform);

            posTweenList = M_Game.I.ObjectTransforms(delayTime);


        }
        if (other.tag == "Lava")
        {
            delayTime = 0.05f;

            transform.SetParent(other.transform);

            posTweenList = M_Game.I.ObjectTransforms(delayTime);

        }
        if (other.tag == "Finish")
        {
            M_Observer.OnGameComplete?.Invoke();
        }
    }


    void GameFail()
    {
        //    if (posTweenList != null)
        //    {
        //        for (int i = 0; i < posTweenList.Count; i++)
        //        {
        //            posTweenList[i].Kill();
        //        }

    }

    //}
    //private void OnCollisionEnter(Collision collision)
    //{

    //}

}
