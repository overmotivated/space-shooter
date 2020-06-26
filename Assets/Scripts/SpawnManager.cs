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
    private GameObject bufsContainer;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject tripleShotPrefab;
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
            Spawn(enemyPrefab);
            Spawn(tripleShotPrefab);
            yield return new WaitForSeconds(spawnInterval);
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
