using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] float moveSpped = 1f;
    Rigidbody2D myRigitBody;

    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFacingRight())
        {
            myRigitBody.velocity = new Vector2(moveSpped, 0f);
        }
        else
        {
            myRigitBody.velocity = new Vector2(-moveSpped, 0f);
        }
    }

    bool isFacingRight()
    {
        return transform.localScale.x>0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigitBody.velocity.x)), 1f);
    }
    
}
