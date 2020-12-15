using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDaeHwa : MonoBehaviour
{
    public GameObject Player;

    Rigidbody2D rigid;  //Rigidbody2D -변수명 rigid 선언 
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float jumpPower;
    public int jumpCount = 2;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //rigid 변수 초기화
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {


    }

    void FixedUpdate()
    {

        //플랫폼에 랜딩하기
        if (rigid.velocity.y < 0)
        {

            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                Debug.Log("rayHit.distance :  " + rayHit.distance);

                if (rayHit.distance <= 0.28f)
                {

                    anim.SetBool("isJumping", false);
                    jumpCount = 2;
                }

            }


        }

    }
}
