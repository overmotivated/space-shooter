using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.5f;
    public float SpeedMult { get; set; } = 1f;
    public bool SheildActivated { get; set; } = false;
    public int LifeCount { get; private set; } = 3;
    public int Score { get; private set; } = 0;


    [SerializeField]
    private SpawnManager spawnManager;
    public event Action GameOver;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float verticInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizInput, verticInput, 0);
        transform.Translate(direction * Time.deltaTime * speed * SpeedMult);

        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, 6f, 0);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector3(10, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        LifeCount--;
        LifeCount = Mathf.Max(LifeCount, 0); // check is needed
        if (LifeCount == 0)
        {
            GameOver?.Invoke();
            spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void AddScore( int num )
    {
        Score += num;
    }
}
