using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 5f;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject enemyPrefab;
    private bool continueSpawn = true;

    private void Start()
    {
        StartCoroutine(DoSpawn());
    }
    void Update()
    {
        
    }

    IEnumerator DoSpawn()
    {
        while (continueSpawn)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Spawn()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-9f, 9f), 10, 0), Quaternion.identity);
        newEnemy.transform.parent = enemyContainer.transform;
    }

    public void OnPlayerDeath()
    {
        continueSpawn = false;
    }
}
