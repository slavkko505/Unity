using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScroll : MonoBehaviour
{
    public float WaterSpeed = 0.2f;
    void Start()
    {
        
    }
    void Update()
    {

        transform.Translate(new Vector2(0f, WaterSpeed * Time.deltaTime));
    }
}
