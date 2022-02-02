using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 3f;
    [SerializeField] Vector2 deathKick = new Vector2(250f,25f);
    

    //Cache for code
    Rigidbody2D myRigitBody;
    Animator myAnim;
    CapsuleCollider2D myBodycollider;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    //GameSession
    GameSession GameSessionPlayer;

    //life
    bool isAlife =true;

    //Joystick
 
    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myBodycollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigitBody.gravityScale;
        GameSessionPlayer = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlife){ return; }

        Run();
        FlipSprite();
        ClimpLadder();
        Die();
        Jump();
    }
    
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigitBody.velocity.y);
        myRigitBody.velocity = playerVelocity;

        // anim for run
        bool playerHasHorizontalySpeed = Mathf.Abs(myRigitBody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Running",playerHasHorizontalySpeed);
    }
    public void Jump()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                myRigitBody.velocity += jumpVelocityToAdd;
            }
        }
    }
    private void Die()
    {
        if (myBodycollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            myAnim.SetTrigger("Dead");
            myRigitBody.velocity = deathKick;
            isAlife = false;

            GameSessionPlayer.ProcessPlayerDeath();   
        }
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalySpeed = Mathf.Abs(myRigitBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalySpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigitBody.velocity.x), 1f);
        }
    }

    private void ClimpLadder()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Lader")))
        {
            float controlY = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 playerVelocityY = new Vector2(myRigitBody.velocity.x, controlY * climbSpeed);
            myRigitBody.velocity = playerVelocityY;

            //anim for climb
            bool playerHasVerticalSpeed = Mathf.Abs(myRigitBody.velocity.y) > Mathf.Epsilon;
            myAnim.SetBool("Climbing", playerHasVerticalSpeed);

            //gravity 0
            myRigitBody.gravityScale = 0f;
        }
        else
        {
            myAnim.SetBool("Climbing", false);
            myRigitBody.gravityScale = gravityScaleAtStart;
        }
    }
   


}
