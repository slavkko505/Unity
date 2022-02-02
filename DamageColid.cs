using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        FindObjectOfType<Lives>().TakeLife();
        Destroy(otherCol.gameObject);
        
    }
}
