﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject restartText;
    [SerializeField]
    private GameObject pauseText;
    [SerializeField]
    private GameObject resumeText;
    private Player playerComponent;
    private int score = 0;
    private int lives;
    [SerializeField]
    private Image liveImage;
    [SerializeField]
    private List<Sprite> livesImages;
    public bool ReadyToRestart { get; private set; } = false;

    private void Start()
    {
        playerComponent = GameObject.Find("Player").GetComponent<Player>();
        scoreText.text = $"Score: {score}";
        playerComponent.GameOver += ShowGameOver;
    }

    private void Update()
    {
        UpdateScore();
        UpdateLivesImage();
    }

    private void UpdateScore()
    {
        score = playerComponent.Score;
        scoreText.text = $"Score: {score}";
    }

    private void UpdateLivesImage()
    {
        lives = playerComponent.LifeCount;
        liveImage.sprite = livesImages[lives];
    }

    private void ShowGameOver()
    {
        gameOver.SetActive(true);
        restartText.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        ReadyToRestart = true;
    }

    public void ShowPauseUI()
    {
        pauseText.SetActive(true);
        resumeText.SetActive(true);
    }

    public void HidePauseUI()
    {
        pauseText.SetActive(false);
        resumeText.SetActive(false);
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOver.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOver.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
