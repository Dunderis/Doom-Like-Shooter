using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float spawnRate;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    void Spawn()
    {
        var enemy = prefabs[Random.Range(0, prefabs.Length)];
        var position = new Vector3();
        position.x = Random.Range(startPosition.x, endPosition.x);
        position.y = 1;
        position.z = Random.Range(startPosition.y, endPosition.y);
        
        Instantiate(enemy, position, Quaternion.identity);
    }
}
