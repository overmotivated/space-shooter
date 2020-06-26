﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private int lifeCount = 2;
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        CalculateMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TripleShot"))
        {
            transform.GetComponent<Fire>().TripleShotAlowed();
            Destroy(other.gameObject);
        }
    }

    void CalculateMovement()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float verticInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizInput, verticInput, 0);
        transform.Translate(direction * Time.deltaTime * speed);

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
        lifeCount--;
        if (lifeCount <= 0)
        {
            spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
