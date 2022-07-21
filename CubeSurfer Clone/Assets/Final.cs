using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public Path[] qwe;
    public GameObject FinalRoads;

    public void Start()
    {
        qwe = GetComponentsInChildren<Path>();
        for (int i = 0; i < qwe.Length; i++)
        {
            for (int j = 0; j < qwe[i].PathTransformsArray.Length; j++)
            {
                M_Game.I.FinalPath.Add(qwe[i].PathTransformsArray[j].position);
            }
        }

    }

}

