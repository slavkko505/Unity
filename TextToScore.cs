using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextToScore : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text textstar;
    void Start()
    {
        textstar = GetComponent<Text>();
        UpdatingDisplay();
    }

    private void UpdatingDisplay()
    {
        textstar.text = stars.ToString();
    }
    public void MinusStar(int starminus)
    {
        if (stars >= starminus)
        {
            stars -= starminus;
            UpdatingDisplay();
        }
        else
        {
            return;
        }
    }
    public void AddStar(int staradd)
    {
        stars += staradd;
        UpdatingDisplay();
    }

    public bool HaveEnoughStar(int val)
    {
        return stars >= val;
    }

}
