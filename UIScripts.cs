using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    [SerializeField] Defender defender;
    private void Start()
    {
        LabelWithCost();
    }

    private void LabelWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.Log("Problema with " + name);
        }
        else
        {
            costText.text = defender.GetStartCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<UIScripts>();
        foreach(UIScripts hero in buttons)
        {
            hero.GetComponent<SpriteRenderer>().color = new Color32(41,41,41,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<AddHereos>().SetSelectedHero(defender);
    }


}
