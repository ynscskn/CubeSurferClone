using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Level : MonoBehaviour
{
    public Level[] Levels;

    [SerializeField] Path[] TurningRoadPrefabs;
    [SerializeField] Path[] LavaRoadPrefabs;
    [SerializeField] Path StandardRoadPrefab;
    [SerializeField] Final FinalPlatformPrefab;
    [SerializeField] Obstacle[] ObstaclePrefabs;

    [HideInInspector] public Level CurrentLevel;
    [HideInInspector] public int LevelIndex;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("LevelIndex"))
        {
            LevelIndex = PlayerPrefs.GetInt("LevelIndex");
        }
        else
        {
            LevelIndex = 0;
        }
    }
    private void Start()
    {
        //CurrentLevel = Instantiate(Levels[LevelIndex], transform);
        CreateNewLevel();
    }

    void CreateNewLevel()
    {
        GameObject Level000 = new GameObject("Level_001");
        Level000.transform.SetParent(this.transform);

        Vector3 nextPos = Vector3.zero;
        Vector3 nextRot = new Vector3(0, 270, 0);
        for (int i = 0; i < 3; i++)
        {
            Path path = Instantiate(StandardRoadPrefab, Level000.transform);
            path.transform.position = nextPos;
            nextPos = path.NextInstantiateTransform.position;
        }
        for (int i = 0; i < 20; i++)
        {
            int RandomSayi = Random.Range(0, 3);
            switch (RandomSayi)
            {
                case 0:
                    Path path_1 = Instantiate(StandardRoadPrefab, Level000.transform);
                    path_1.transform.position = nextPos;
                    path_1.transform.eulerAngles = nextRot;

                    nextPos = path_1.NextInstantiateTransform.position;
                    break;
                case 1:
                    Path path_2 = Instantiate(LavaRoadPrefabs[Random.Range(0, LavaRoadPrefabs.Length)], Level000.transform);
                    path_2.transform.position = nextPos;
                    path_2.transform.eulerAngles = nextRot;

                    nextPos = path_2.NextInstantiateTransform.position;
                    break;
                case 2:

                    Path path_3 = Instantiate(TurningRoadPrefabs[0], Level000.transform);//left
                    path_3.transform.position = nextPos;
                    path_3.transform.eulerAngles = nextRot;

                    nextPos = path_3.NextInstantiateTransform.position;
                    nextRot -= new Vector3(0, -90, 0);
                    break;
                default:
                    break;
            }
        }
    }
}
