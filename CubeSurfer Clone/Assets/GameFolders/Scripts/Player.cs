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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Cube"))
        {
            currentCube = other.gameObject;
            currentCube.transform.SetParent(cubeConteiner);

            currentCube.transform.localPosition = (cubeConteiner.transform.childCount - 1) * new Vector3(0, 2, 0);
            M_Game.I.CurrentPlayer.transform.DOLocalMove(cubeConteiner.transform.childCount * new Vector3(0, 2, 0), 0.25f).SetEase(Ease.OutExpo);
            M_Game.I.CurrentPlayer.transform.DOLocalRotate(Vector3.zero, 0.25f).SetEase(Ease.OutExpo);
            M_Game.I.SetCamera();
            currentCube = null;
        }
        if (other.transform.CompareTag("TurnLeft"))
        {
            other.tag = "Untagged";
            DOTween.To(() => CameraMultiTarget.Yaw, x => CameraMultiTarget.Yaw = x, CameraMultiTarget.Yaw - 90f, 2f);//.SetEase(Ease.OutExpo);
        }
        if (other.transform.CompareTag("TurnRight"))
        {
            other.tag = "Untagged";
            DOTween.To(() => CameraMultiTarget.Yaw, x => CameraMultiTarget.Yaw = x, CameraMultiTarget.Yaw + 90f, 2f);//.SetEase(Ease.OutExpo);
        }
        if (other.transform.CompareTag("Finish"))
        {
            M_Observer.OnGameComplete?.Invoke();
        }
    }
}
