using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;
    void Start()
    {
        lives = baseLives - PlayerPrefControler.GetDifficuly();
        livesText = GetComponent<Text>();
        UpdatingDisplay();
    }

    private void UpdatingDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
         lives -= damage;
         UpdatingDisplay();

        if(lives <= 0)
        {
            FindObjectOfType<levelController>().HandleLoseCondition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
