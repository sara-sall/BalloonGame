using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour{

    public GameObject player;
    public GameObject[] trianglePrefabs;
    public GameObject coins;
    public GameObject invinciPill;
    private Vector3 spawnObstaclePosition;
 

    // Update is called once per frame
    void Update(){
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if(distanceToHorizon < 120){
            SpawnTriangles();
            SpawnCoins();
            //SpawnInvinciPill();
        }
    }

    void SpawnTriangles(){
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 30);
        Instantiate(trianglePrefabs[(Random.Range(0, trianglePrefabs.Length))], spawnObstaclePosition, Quaternion.identity);
    }

    void SpawnCoins()
    {
        spawnObstaclePosition = new Vector3(Random.Range(-2, 3), 0, spawnObstaclePosition.z + Random.Range(3, 20));
        Instantiate(coins, spawnObstaclePosition, Quaternion.identity);

    }

    void SpawnInvinciPill()
    {
        spawnObstaclePosition = new Vector3(Random.Range(-2, 3), 0, spawnObstaclePosition.z + Random.Range(100, 400));
        Instantiate(invinciPill, spawnObstaclePosition, Quaternion.identity);
    }
}
