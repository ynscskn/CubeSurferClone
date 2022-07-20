using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Transform cubeConteiner;
    public GameObject currentCube;
    public CameraMultiTarget CameraMultiTarget;

    void Start()
    {
        cubeConteiner = M_Game.I.CubeConteiner;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Cube"))
        {
            currentCube = other.gameObject;
            currentCube.transform.SetParent(cubeConteiner);
            print(cubeConteiner.transform.childCount);

            currentCube.transform.localPosition = (cubeConteiner.transform.childCount - 1) * new Vector3(0, 2, 0);
            M_Game.I.CurrentPlayer.transform.DOLocalMove(cubeConteiner.transform.childCount * new Vector3(0, 2, 0), 0.25f).SetEase(Ease.OutExpo);
            M_Game.I.CurrentPlayer.transform.DOLocalRotate(Vector3.zero, 0.25f).SetEase(Ease.OutExpo);
            currentCube = null;
        }
        if (other.transform.CompareTag("TurnLeft"))
        {
        }
        if (other.transform.CompareTag("TurnRight"))
        {
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.tag == "Engel" || other.transform.tag == "Lav")
    //    {
    //        M_Observer.OnGameFail?.Invoke();
    //    }
    //    if (other.transform.tag == "Finish")
    //    {
    //        M_Observer.OnGameComplete?.Invoke();
    //    }
    //}

}
