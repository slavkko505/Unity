using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonTypePrefab : MonoBehaviour
{
    [SerializeField] public Directionint _directionint;
    
    public enum Directionint
    {
        right,
        left,
        jump
    }
}
