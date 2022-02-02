using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePersist : MonoBehaviour
{
    int StartIndexScene;
    private void Awake()
    {
        int numPersist = FindObjectsOfType<ScenePersist>().Length;
        if(numPersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        Debug.Log(numPersist);
    }
    void Start()
    {
        StartIndexScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != StartIndexScene)
        {
            Destroy(gameObject);
        }
        
    }
}
