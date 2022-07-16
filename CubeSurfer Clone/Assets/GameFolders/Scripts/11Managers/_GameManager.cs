using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Path[] PlatformPrefabs;
    public Transform ContainerTransform;
    public Transform PlayerContainerTransform;
    public GameObject[] ObstaclesPrefabs;
    public GameObject Cube;
    public GameObject FinishRing;
    int platformSize = 20;
    int platformNumber;
    List<Vector3> PathList;
    float playerPosX;
    Vector3 instantiatePos = new Vector3(0,0,0);
    Vector3 instantiateRot = new Vector3(0,-90,0);
    Tween PathMove;
   // Quaternion instantiateRot;
    private void Awake()
    {
        PathList = new List<Vector3>();
        M_Observer.OnGameCreate += PlatformCreate;
        M_Observer.OnGameStart += PlayerCreate;
        M_Observer.OnGameFail += GameFail;
    }
    private void OnDestroy()
    {
        M_Observer.OnGameCreate -= PlatformCreate;
        M_Observer.OnGameStart += PlayerCreate;
        M_Observer.OnGameFail -= GameFail;


    }
    private void OnEnable()
    {
        FingerGestures.OnFingerDragMove += FingerGestures_OnFingerDragMove;

    }

   
    private void OnDisable()
    {
        FingerGestures.OnFingerDragMove -= FingerGestures_OnFingerDragMove;

    }



    private void FingerGestures_OnFingerDragMove(int fingerIndex, Vector2 fingerPos, Vector2 delta)
    {
        if (delta.x < 0)
        {
            playerPosX -= Vector3.right.x/10;
            playerPosX = Mathf.Clamp(playerPosX, -4, 4);
            PlayerContainerTransform.localPosition = new Vector3(playerPosX, 0, 0);
        }
        if (delta.x > 0)
        {
            playerPosX += Vector3.right.x/10;
            playerPosX = Mathf.Clamp(playerPosX, -4, 4);
            PlayerContainerTransform.localPosition = new Vector3(playerPosX, 0, 0);
        }
        // playerPosX = Mathf.Clamp(fingerPos.y, -4, 4);
        
    }

    private void PlatformCreate()
    {
        int engel = 0;
        for (int i = 0; i < platformSize; i++)
        {
            int obstacleInstantiateNumber;
            int canInstantiateObstacle;
            int CubeInstantiatePosMax = 4;
            int CubeInstantiateposMin=-4;
    platformNumber = Random.Range(0,PlatformPrefabs.Length);
           
            Path platformPiece = Instantiate(PlatformPrefabs[platformNumber]);
            platformPiece.transform.position = instantiatePos;
            platformPiece.transform.eulerAngles = instantiateRot;
            platformPiece.transform.SetParent(transform);
            canInstantiateObstacle = Random.Range(0,2);

                if (engel == 3 && i!=0)
                {
                  engel = -1;
                    obstacleInstantiateNumber = Random.Range(0, ObstaclesPrefabs.Length);

                    GameObject obstacle = Instantiate(ObstaclesPrefabs[obstacleInstantiateNumber]);
                    obstacle.transform.position = instantiatePos;
                    obstacle.transform.eulerAngles = instantiateRot;
                    obstacle.transform.SetParent(platformPiece.transform);
                }
            for (int b = 0; b < platformPiece.PathTransformsArray.Length; b++)
            {
                if (b!= platformPiece.PathTransformsArray.Length-1)
                {
                    if (platformNumber == 0)
                    {
                        CubeInstantiatePosMax = 0;
                        CubeInstantiateposMin = 0;
                    }
                    else if(platformNumber == 1)
                    {
                        CubeInstantiatePosMax = 4;
                        CubeInstantiateposMin = 0;
                    }else if (platformNumber == 2)
                    {
                        CubeInstantiatePosMax = 0;
                        CubeInstantiateposMin = -4;
                    }
                    GameObject _cube = Instantiate(Cube, platformPiece.transform);
                    _cube.transform.position = platformPiece.PathTransformsArray[b].transform.position + new Vector3(Random.Range(CubeInstantiateposMin, CubeInstantiatePosMax), 0, 0);
                    
                    //_cube.transform.eulerAngles = platformPiece.PathTransformsArray[b].transform.eulerAngles;
                }

            }
            for (int a = 0; a < platformPiece.PathTransformsArray.Length; a++)
            {
                PathList.Add(platformPiece.PathTransformsArray[a].position);
            }
            instantiatePos = platformPiece.NextInstantiateTransform.position;
            instantiateRot = platformPiece.NextInstantiateTransform.eulerAngles;
            engel++;

        }
        GameObject finishRing = Instantiate(FinishRing);
        finishRing.transform.position = instantiatePos;
        finishRing.transform.eulerAngles = instantiateRot + new Vector3(0,90,0) ;
        finishRing.transform.SetParent(transform);

        PathList.Add(finishRing.transform.position);
      
      
    }
    private void PlayerCreate()
    {
      PathMove =  ContainerTransform.DOPath(PathList.ToArray() , 20).SetLookAt(0.07f).SetEase(Ease.Linear).SetSpeedBased();
        
    }
    void GameFail()
    {
        PathMove.Kill();
        FingerGestures.OnFingerDragMove -= FingerGestures_OnFingerDragMove;
    }
   
}
