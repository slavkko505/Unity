using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in Second")]
    [SerializeField] float levelTime = 10f;
    bool triggertLevelFinished = false;

    void Update()
    {
        if(triggertLevelFinished == true) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<levelController>().LevelTimerFinished();
            triggertLevelFinished = true;
        }
    }
}
