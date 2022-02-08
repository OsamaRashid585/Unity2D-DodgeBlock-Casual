using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectPrefab = new GameObject[5];
     private Vector2[] _objectPrefabPos = new Vector2[5];
   [SerializeField] private GameObject _lifePrefab;
    private Vector2 _lifePrefabPos;

    private void Awake()
    {
    }
    void Start()
    {
        InvokeRepeating("ObjectSpawner", 3f, 2.3f);

        InvokeRepeating("LifeSpawner", 12, 20);
    }

    private void ObjectSpawner()
    {
        _objectPrefabPos[0] = new Vector2(-6.5f, 7f);
        _objectPrefabPos[1] = new Vector2(-3.2f, 7f);
        _objectPrefabPos[2] = new Vector2(0f, 7f);
        _objectPrefabPos[3] = new Vector2(3.2f, 7f);
        _objectPrefabPos[4] = new Vector2(6.5f, 7f);

        int randNum = Random.Range(0, 5);

        for (int i = 0; i < 5; i++)
        {
            if (i != randNum)
            {
                Instantiate(_objectPrefab[i], _objectPrefabPos[i], Quaternion.identity);
            }
        }
    }

    private void LifeSpawner()
    {
        int randPos = Random.Range(-7, 7);
        _lifePrefabPos = new Vector2(randPos, -3.86f);
        Instantiate(_lifePrefab, _lifePrefabPos,Quaternion.identity);
    }
}
