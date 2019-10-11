using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject[] coins;
    private Vector3 spawnCoinPosition;

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnCoinPosition);
        if (distanceToHorizon < 120)
        {
            SpawnCoins();
        }
    }

    void SpawnCoins()
    {
        spawnCoinPosition = new Vector3(0, 0, spawnCoinPosition.z + 30);
        Instantiate(coins[(Random.Range(0, coins.Length))], spawnCoinPosition, Quaternion.identity);

    }
}
