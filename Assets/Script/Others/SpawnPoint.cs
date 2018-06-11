using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject enemy;              
    private float spawnTime = 3f;           
    public Transform[] spawnPoints;         


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime - 1);
    }


    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
