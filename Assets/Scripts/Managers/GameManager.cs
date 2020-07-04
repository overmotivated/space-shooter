﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameUICanvas;
    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private UIManager UIManager;
    [SerializeField]
    private SpawnManager SpawnManager;
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        mainMenuCanvas.SetActive(true);
        gameUICanvas.SetActive(false);
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerSpriteRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && UIManager.ReadyToRestart)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);  //Game Scene
    }

    public void StartNewGame()
    {
        mainMenuCanvas.SetActive(false);
        gameUICanvas.SetActive(true);
        player.transform.position = new Vector3(0,0,0);
        playerSpriteRenderer.enabled = true;
        SpawnManager.StartSpawn();
    }
}