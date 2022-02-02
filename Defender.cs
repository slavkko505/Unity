using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int startcost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<TextToScore>().AddStar(amount);
    }
    public int GetStartCost()
    {
        return startcost;
    }

}
