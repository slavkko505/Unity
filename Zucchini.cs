using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zucchini : MonoBehaviour
{
    [SerializeField] float damage = 50f;
    [SerializeField] float currentSpeed = 1.13f;

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<HealthMinus>();
        var attaker = other.GetComponent<Attaka>();

        if( attaker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
