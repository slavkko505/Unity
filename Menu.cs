using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
 
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadOtionsScene()
    {
        SceneManager.LoadScene("Core Menu");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Screen");
    }
    public void RestartGame()
    {
        //SceneManager.LoadScene(FindObjectOfType<Player>().GetCurrentSceneIndex());
        Debug.Log(FindObjectOfType<GameSession>().GetCurrentSceneIndex());
    }
}
