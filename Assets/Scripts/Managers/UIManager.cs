using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private Player playerComponent;
    private int score = 0;
    private int lives;
    [SerializeField]
    private Image liveImage;
    [SerializeField]
    private List<Sprite> livesImages;

    void Start()
    {
        playerComponent = GameObject.Find("Player").GetComponent<Player>();
        scoreText.text = $"Score: {score}";
    }

    void Update()
    {
        UpdateScore();
        UpdateLivesImage();
    }

    void UpdateScore()
    {
        score = playerComponent.Score;
        scoreText.text = $"Score: {score}";
    }

    void UpdateLivesImage()
    {
        lives = playerComponent.LifeCount;
        liveImage.sprite = livesImages[lives];
    }
}
