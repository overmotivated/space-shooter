﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float enemySpawnInterval = 5f;
    [SerializeField]
    private float powerupSpawnInterval = 3f;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject bufsContainer;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private List<GameObject> powerupPrefabs;
    private bool continueSpawn = true;

    private void Start()
    {
        StartCoroutine(DoSpawnEnemy());
        StartCoroutine(DoSpawnPowerup());
    }
    void Update()
    {
        
    }

    IEnumerator DoSpawnEnemy()
    {
        while (continueSpawn)
        {
            Spawn(enemyPrefab);
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    IEnumerator DoSpawnPowerup()
    {
        while (continueSpawn)
        {
            Spawn(powerupPrefabs.GetRandomItem<GameObject>());
            yield return new WaitForSeconds(powerupSpawnInterval);
        }
    }

    void Spawn(GameObject prefab)
    {
        GameObject newPrefab = Instantiate(prefab, new Vector3(Random.Range(-9f, 9f), 10, 0), Quaternion.identity);
        
        if (prefab.transform.CompareTag("Enemy"))
        {
            newPrefab.transform.parent = enemyContainer.transform;
        }
        else
        {
            newPrefab.transform.parent = bufsContainer.transform;
        }
    }

    public void OnPlayerDeath()
    {
        continueSpawn = false;
    }
}