using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    void Awake()
    {
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void processPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakePlayerLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakePlayerLife()
    {
        playerLives --;
        int curentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curentSceneIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
