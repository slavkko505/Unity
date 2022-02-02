using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class playerControler : MonoBehaviour
{
    [SerializeField] float teleportDirection =2f;
    [SerializeField] private GameObject leftButt;
    [SerializeField] private GameObject rightButt;
    [SerializeField] private GameObject spaceButt;
    
    private Animator anim;
    public CharacterController2D controller;
    
    private float horizontalMove = 0f;
    public float runSpeed =10f;
    private bool jump =false;
    public bool isCanJump;

    private bool isRight = true;
    private bool isLeft = true;
    private bool isJump = true;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalControl();
        AnimRunControl();
        JumpControl();

    }
    
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    
    void HorizontalControl()
    {
        if (isLeft && isRight)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
        }
        if (!isRight)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            if (horizontalMove > 0)
            {
                horizontalMove = 0;
            }
        }
        if (!isLeft)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            if (horizontalMove < 0)
            {
                horizontalMove = 0;
            }
        }
        if (!isLeft && !isRight)
        {
            horizontalMove = 0;
        }
    }

    void AnimRunControl()
    {
        if (Input.GetKey(KeyCode.A)&& isLeft || Input.GetKey(KeyCode.D) && isRight || Input.GetKey(KeyCode.LeftArrow)&& isLeft || Input.GetKey(KeyCode.RightArrow) && isRight)
        {
            anim.SetBool("playerRun", true);
        }
        else
        {
            anim.SetBool("playerRun", false); 
        }
    }

    void JumpControl()
    {
        if (Input.GetButtonDown("Jump") && isJump && isCanJump)
        {
            isCanJump = false;
            jump = true;
            StartCoroutine(playerJump());
        }
    }
    
    IEnumerator playerJump()
    {
        anim.SetBool("playerJump", true);

        yield return new WaitForSecondsRealtime(0.3f);
        
        transform.position += new Vector3(teleportDirection*horizontalMove,0f,0f);
        
        yield return new WaitForSecondsRealtime(0.5f);
        anim.SetBool("playerJump", false);

    }
    
    public void DisebleToMove(string i)
    {
        switch (i)
        {
            case "right":
                isRight = false;
                break;
            case "left":
                isLeft = false;
                break;
            case "jump":
                isJump = false;
                break;
            default:
                break;
        }
    }
    public void EnableToMove(string i)
    {
        switch (i)
        {
            case "right":
                isRight = true;
                break;
            case "left":
                isLeft = true;
                break;
            case "jump":
                isJump = true;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isCanJump = true;
        }
    }
    
    
    
}
