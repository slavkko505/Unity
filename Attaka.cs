using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaka : MonoBehaviour
{

    float currentSpeed = 1.13f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<levelController>().AtackerSpawner();
    }

    private void OnDestroy()
    {
        levelController levelCon =  FindObjectOfType<levelController>();
        if(levelCon != null)
        {
            levelCon.AtackerKilled();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left *currentSpeed* Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttaking", false);
        }
    }

    public void SetCurrentSpeed(float val)
    {
        currentSpeed = val;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttaking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        HealthMinus health = currentTarget.GetComponent<HealthMinus>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
