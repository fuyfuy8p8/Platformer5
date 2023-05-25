using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple: MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Apple _apple;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_apple, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
