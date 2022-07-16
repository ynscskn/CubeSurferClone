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
        if (other.tag == "Engel")
        {
            delayTime = 0.25f;
            GameObject _hamburger = gameObject;
            _hamburger.transform.tag = "Bos";
            transform.SetParent(other.transform);

            posTweenList= PlayerContainer.II.ObjectTransforms(delayTime);


        }
        if (other.tag == "Lav")
        {
            delayTime = 0.05f;
            GameObject _hamburger = gameObject;
            _hamburger.transform.tag = "Bos";
            transform.SetParent(other.transform);

            posTweenList= PlayerContainer.II.ObjectTransforms(delayTime);

        }
        if (other.tag == "Finish")
        {
            M_Observer.OnGameComplete?.Invoke();
        }
    }
    void GameFail()
    {
        if (posTweenList!=null)
        {
            for (int i = 0; i < posTweenList.Count; i++)
            {
                posTweenList[i].Kill();
            }

        }
        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
  
}
