using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraweStone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D othercollision)
    {
        Attaka attacker = othercollision.GetComponent<Attaka>();

        if (attacker)
        {

        }
    }
}
