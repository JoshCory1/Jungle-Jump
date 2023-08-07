using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] int CoinScoreing;
    [SerializeField] float DeathDelay =1.5f;
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
    private void Start() 
    {
        CoinText.text = CoinScoreing.ToString();
        LivesText.text = playerLives.ToString();    
    }

    public void processPlayerDeath()
    {
        Invoke("InvokeDeath", DeathDelay);
    }

    private void InvokeDeath()
    {
        if (playerLives > 1)
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
        LivesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScreenPersist>().ScreenDestroy();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        
    }
    public void processScores(int pointsToAdd)
    {
        CoinScoreing += pointsToAdd;
        CoinText.text = CoinScoreing.ToString();
        
    }
}
