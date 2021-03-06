﻿using System;
using System.Collections;
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
    private Fire fireComponent;
    private Asteroid asteroidComponent;
    private bool isGamePaused = false;

    private void Start()
    {
        mainMenuCanvas.SetActive(true);
        gameUICanvas.SetActive(false);
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        fireComponent = player.GetComponent<Fire>();
        playerSpriteRenderer.enabled = false;
        fireComponent.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && UIManager.ReadyToRestart)
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.P) && isGamePaused)
        {
            isGamePaused = false;
            UIManager.HidePauseUI();
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isGamePaused)
        {
            isGamePaused = true;
            UIManager.ShowPauseUI();
            Time.timeScale = 0;
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
        SpawnManager.SpawnAsteroid();
        player.transform.position = new Vector3(0,0,0);
        playerSpriteRenderer.enabled = true;
        fireComponent.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
