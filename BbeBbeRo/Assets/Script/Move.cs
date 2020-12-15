﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Move : MonoBehaviour
{
    public GameObject Player;
    public GameObject SoundObject;
    float maxSpeed;          //최대속도변수 선언
    Rigidbody2D rigid;  //Rigidbody2D -변수명 rigid 선언 
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float jumpPower;
    public int jumpCount=2;
    public int spaceCount = 0;
    public int score = 0;

    public void setJumpPower(float value)
    {
        jumpPower = value;
    }

    public void setScore(int value) {
        score += value;
    }

    public int getScore()
    {
        return score;
    }

    private void OnGUI()
    {
        GUILayout.Label("<color=#000000>" +"모은 동전 수:" + score.ToString() + " /24"+ "</color>");
    }



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //rigid 변수 초기화
        maxSpeed = 2f;              //최대속도
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //동전 휙득하기
        if (other.gameObject.tag == "Coin")
        {

            //소리나게 하기
            SoundObject.GetComponent<AudioSource>().Play();

            //점수얻기
            score++;
            //사라지게 하기
            Destroy(other.gameObject , 0f);

        }

    }

    void Update()
    {

        //점프
        if (Input.GetButtonDown("Jump")  &&(jumpCount > 0 ))
        {
          
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount--;
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
            //사운드
            AudioSource jumpSound = Player.GetComponent<AudioSource>();
            jumpSound.Play();

            spaceCount++;


        }



        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.25f, rigid.velocity.y);
            //키를 떼면,x축 속도 기본 0.25배, y축 속도는 그대로
        }
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            //키를 누르고 있으면, 왼쪽누르면 -1되서 좌우바꾸기
        }

        //워킹 애니메이션 관련 
        if (Mathf.Abs(rigid.velocity.normalized.x ) < 0.25)
        {
            anim.SetBool("isWalking", false);
        }
        else {
            anim.SetBool("isWalking", true);
        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");       //h에 키를 누르면 입력 오른쪽=1,왼쪽=-1
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //h * 오른쪽곱해서 힘을 줌

        if (rigid.velocity.x > maxSpeed)         //x속도가 maxSpeed 보다 크면, 속도 maxSpeed로 고정
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))       //x속도가 -maxSpeed 보다 작으면(왼쪽으로 갈때) 속도는 -maxSpeed로 고정
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);


        //플랫폼에 랜딩하기
        if (rigid.velocity.y < 0) {

            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                Debug.Log("rayHit.distance :  " + rayHit.distance);

                if (rayHit.distance <= 0.28f) {
                    
                    anim.SetBool("isJumping", false);
                    jumpCount = 2;
                }

            }


        }

    }
}
