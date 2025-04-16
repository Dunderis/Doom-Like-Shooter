using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("SpawnPoints")]
    public Transform[] gunSpawnPoints;
    public Transform[] buffSpawnPoints;
    public Transform[] enemySpawnPoints;
    public Transform[] notesSpawnPoints;
    [Space()]
    [Header("Prefab linkers")]
    public GameObject[] gunPrefabs;
    public GameObject[] buffPrefabs;
    public GameObject[] enemyPrefabs;
    public GameObject[] notes;


    [Space()]
    [Space()]
    [Space()]

    [Header("Main settings")]
    [Range(0, 1)]public float gunSpawnDensity = 0.8f;

    [Range(0, 1)]public float enemySpawnDensity = 0.5f;
    [Range(0, 1)]public float probabilityOfBossSpawning = 0;
    public float rangeBetweenEnemySpawnWaves = 0;

    private void Start()
    {
        StartSpawn();
    }

    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rangeBetweenEnemySpawnWaves)
        {
            for (int i = 0; i < enemySpawnPoints.Length; i++)
            {
                var currentProbability = Random.value;
                if (currentProbability <= enemySpawnDensity/2)
                {
                    Instantiate(enemyPrefabs[(int)Random.Range(0, enemyPrefabs.Length - 1)], enemySpawnPoints[i].position, Quaternion.identity, parent: GetComponentInParent<Terrain>().gameObject.transform);
                }
            }
            timer = 0;
        }
    }
    public void StartSpawn()
    {
        //Gun spawning
        for (int i = 0; i < gunSpawnPoints.Length; i++)
        {
            var currentProbability = Random.value;
            if (currentProbability <= gunSpawnDensity)
            {
                Instantiate(gunPrefabs[(int)Random.Range(0, gunPrefabs.Length - 1)], gunSpawnPoints[i].position, Quaternion.identity, parent: GetComponentInParent<Terrain>().gameObject.transform);
            }
        }

        //Buff spawning
        for (int i = 0; i < buffSpawnPoints.Length; i++)
        {
            Instantiate(buffPrefabs[(int)Random.Range(0, buffPrefabs.Length - 1)], buffSpawnPoints[i].position, Quaternion.identity, parent: GetComponentInParent<Terrain>().gameObject.transform);
        }

        //Enemy spawning
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            var currentProbability = Random.value;
            if (currentProbability <= enemySpawnDensity)
            {
                // TODO: Implement enemies to-boss-upgrade's logic (which depends on 'probabilityOfBossSpawning')
                Instantiate(gunPrefabs[(int)Random.Range(0, enemyPrefabs.Length - 1)], enemySpawnPoints[i].position, Quaternion.identity, parent: GetComponentInParent<Terrain>().gameObject.transform);
            }
        }

        // Note spawning
        for (int i = 0; i < notesSpawnPoints.Length; i++)
        {
            Instantiate(notes[(int)Random.Range(0, notes.Length - 1)], notesSpawnPoints[i].position, Quaternion.identity, parent: GetComponentInParent<Terrain>().gameObject.transform);
        }
    }
}
