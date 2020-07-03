using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player playerComponent;
    private UIManager UIManager;

    private void Start()
    {
        playerComponent = GameObject.Find("Player").GetComponent<Player>();
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
}
