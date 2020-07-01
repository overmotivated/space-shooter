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

    void Start()
    {
        playerComponent = GameObject.Find("Player").GetComponent<Player>();
        scoreText.text = $"Score: {score}";
    }

    void Update()
    {
        score = playerComponent.score;
        scoreText.text = $"Score: {score}";
    }
}
