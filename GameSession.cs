using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [SerializeField] float playerLifes = 3f;
    [SerializeField] float score = 0f;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    //GameScenesIndex
    int currentSceneIndex;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livesText.text = playerLifes.ToString();
        scoreText.text = score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if(playerLifes > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    public void AddToScore(float num)
    {
        score += num;
        scoreText.text = score.ToString();
    }
    private void ResetGameSession()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("End");
        Destroy(gameObject);
    }
    private void TakeLife()
    {
        playerLifes--;
        var currentGameScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentGameScene);
        livesText.text = playerLifes.ToString();
    }
    public int GetCurrentSceneIndex()
    {
        return currentSceneIndex;
    }
}
