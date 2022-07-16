using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerContainer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cubes;
    public GameObject PlayerPrefab;

    private void Awake()
    {
        II = this;
        M_Observer.OnGameStart += PlayerCreate;
    }
    private void OnDestroy()
    {
        M_Observer.OnGameStart -= PlayerCreate;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayerCreate()
    {
        GameObject _player = Instantiate(PlayerPrefab,Player.transform);
        _player.transform.localPosition = Vector3.zero;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Hamburger")
        {
          
            GameObject _hamburger = Instantiate( other.gameObject);
            _hamburger.transform.position = Cubes.transform.position;
            _hamburger.transform.SetParent(Cubes.transform);
            _hamburger.transform.localPosition = (Cubes.transform.childCount-1) * new Vector3(0,2,0);
            Player.transform.localPosition = Cubes.transform.childCount * new Vector3(0,2,0);
            _hamburger.transform.localEulerAngles = new Vector3(-90, 0, 0);

            Destroy(other.gameObject);
        }
    }
    public List<Tween> ObjectTransforms(float delayTime)
    {
        List<Tween> playerTweenList = new List<Tween>();
        int posY=0;
        for (int i = 0; i < Cubes.transform.childCount; i++)
        {
            Tween _cubeTween = Cubes.transform.GetChild(i).transform.DOLocalMove(new Vector3( 0,posY,0) , 20).SetDelay(delayTime).SetSpeedBased();
            playerTweenList.Add(_cubeTween);
            posY += 2;
        }
      Tween _playerTween =   Player.transform.DOLocalMove(new Vector3 (0,posY,0),16).SetDelay(delayTime).SetSpeedBased();
        playerTweenList.Add(_playerTween);
        return playerTweenList;
    }
   
  
    public static PlayerContainer II;

    public static PlayerContainer I
    {
        get
        {
            if (II == null)
            {
                GameObject _g = GameObject.Find("PlayerContainer");
                if (_g != null)
                {
                    II = _g.GetComponent<PlayerContainer>();
                }
            }

            return II;
        }
    }
    IEnumerator waitSecond()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
