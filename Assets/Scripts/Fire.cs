﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleLaserPrefab;
    float shootAlowedTime = -1f;
    [SerializeField]
    float shootCd = 0.3f;
    private bool tripleShotAlowed = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > shootAlowedTime)
        {
            Pewpew();
        }
    }

    void Pewpew()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
        shootAlowedTime = Time.time + shootCd;
        if (tripleShotAlowed)
        {
            Instantiate(tripleLaserPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, spawnPos + new Vector3(0, 0.9f, 0), Quaternion.identity);
        }
    }
}