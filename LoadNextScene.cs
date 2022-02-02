using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNextScene : MonoBehaviour
{
    [SerializeField] float SecondToEndScene = 2f;
    [SerializeField] float SlowTimeLevelOnEnd = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(NextLevel());
    }
    IEnumerator NextLevel()
    {
        Time.timeScale = SlowTimeLevelOnEnd;
        yield return new WaitForSecondsRealtime(SecondToEndScene);
        Time.timeScale = 1f;

        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);

    }
    
   
}
