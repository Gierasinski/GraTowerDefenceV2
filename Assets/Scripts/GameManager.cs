using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    private void Start()
    {
        GameIsOver = false;
    }

    public GameObject gameOverUI;
    void Update()
    {
        if (GameIsOver)
            return;
        //if (Input.GetKeyDown("e"))
          //  EndGame();
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        Debug.Log("GameOver!");

        gameOverUI.SetActive(true);
    }
}
