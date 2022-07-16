using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Engel" || other.transform.tag == "Lav")
        {
            M_Observer.OnGameFail?.Invoke();
        }
        if (other.transform.tag == "Finish")
        {
            M_Observer.OnGameComplete?.Invoke();
        }
    }
   
}
