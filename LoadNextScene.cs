using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNextScene : MonoBehaviour
{
    int curentSceneIndex;
    [SerializeField] int TimeToWay = 4;
    void Start()
    {
        curentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (curentSceneIndex == 0)
        {
            StartCoroutine(WaitForSecond());
        }
    }

    void Update()
    {

    }
    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(TimeToWay);
        StartNextScene();
    }
    public void StartNextScene()
    {
        SceneManager.LoadScene(curentSceneIndex+1);
    }
    public void RestarScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(curentSceneIndex);
    }
    public void LoadMainMenur()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen 1");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
    public void LoseScene()
    {
        SceneManager.LoadScene("End");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
