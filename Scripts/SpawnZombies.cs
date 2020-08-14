using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnZombies : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] playerSpawn;
    public GameObject zombie;
    public GameObject smallzombie;

    private void Start()
    {
        Spawn();
        InvokeRepeating("SpawnOnPlayer", 120f, 120f);
    }

    public void Spawn()
    {
        Instantiate(zombie, spawnPoints[0].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[1].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[2].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[3].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[4].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[5].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[6].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[7].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[8].position, Quaternion.identity);
        Instantiate(zombie, spawnPoints[9].position, Quaternion.identity);
    }

    public void SpawnOnPlayer()
    {
        Debug.Log("spawning small zombies on player");
        Instantiate(smallzombie, playerSpawn[0].position, Quaternion.identity);
        Instantiate(smallzombie, playerSpawn[1].position, Quaternion.identity);
        Instantiate(smallzombie, playerSpawn[2].position, Quaternion.identity);
        Instantiate(smallzombie, playerSpawn[3].position, Quaternion.identity);
        Instantiate(smallzombie, playerSpawn[4].position, Quaternion.identity);
    }
}
