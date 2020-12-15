using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Move2 : MonoBehaviour
{
    public GameObject Player;

    float maxSpeed;          //최대속도변수 선언
    Rigidbody2D rigid;  //Rigidbody2D -변수명 rigid 선언 
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float jumpPower;
    public int jumpCount = 2;
    public int spaceCount = 0;
    public int score = 0;


    public GameObject SoundObject2; //개소리
    public GameObject SoundObject3; //돼지
    public GameObject SoundObject4; //얘야

    //텍스트
    public Text talkText;
    public Text nameText;
    int DialogNum = 0;
    //이미지
    public Image OriginImage; //기존에 존재하는 이미지
    public Image OriginImage_coupon;
    public Sprite NewSprite1; //바뀌어질 이미지 까미
    public Sprite NewSprite2; //바뀌어질 이미지 빼빼로
    public Sprite NewSprite3; //바뀌어질 이미지 돼지
    public Sprite NewSprite4; //바뀌어질 이미지 아몬드

    public GameObject PauseUI;
    public GameObject CouponUI;
    int endingNum;

    public void setJumpPower(float value)
    {
        jumpPower = value;
    }

    public void setScore(int value)
    {
        score += value;
    }

    public int getScore()
    {
        return score;
    }



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //rigid 변수 초기화
        maxSpeed = 2f;              //최대속도
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void ChangeImage(Sprite NewSprite)
    {
        OriginImage.sprite = NewSprite;
        //TestImage에 SourceImage를 TestSprite에 존재하는 이미지로 바꾸어줍니다
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        //동전 휙득하기
        if ((other.gameObject.tag == "Ggamy"))
        {

            //개소리나게 하기
            SoundObject2.GetComponent<AudioSource>().Play();

            //대화 시작하기
            PauseUI.SetActive(true);
            //까미 이미지
            ChangeImage(NewSprite1); //까미
            nameText.text = "까미";
            int endingNum = PlayerPrefs.GetInt("GiveEnding") + PlayerPrefs.GetInt("BadEnding");
            talkText.text = "지금까지 얻은 엔딩 수는 2개 중에서 " + endingNum + "개야";
            

        }

        else if ((other.gameObject.tag == "BadEnding"))
        {

            //돼지소리 하기
            SoundObject3.GetComponent<AudioSource>().Play();

            CouponUI.SetActive(true);
            OriginImage_coupon.sprite = NewSprite4;

            //대화 시작하기
            PauseUI.SetActive(true);
            //까미 이미지
            ChangeImage(NewSprite2); //빼빼로
            nameText.text = "한비가 준 돼지 빼빼로";
            talkText.text = "9915-8289-0040...꿀꿀.";


        }

        else if ((other.gameObject.tag == "GoodEnding"))
        {

            //얘야 소리 내기
            SoundObject4.GetComponent<AudioSource>().Play();

            CouponUI.SetActive(true);
            OriginImage_coupon.sprite = NewSprite3;

            //대화 시작하기
            PauseUI.SetActive(true);
            //까미 이미지
            ChangeImage(NewSprite2); //빼빼로
            nameText.text = "한비가 준 아몬드 빼빼로";
            talkText.text = "9911-1585-2862...인생은 생각대로 되지 않는 법이란다?";


        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        //동전 휙득하기
        if ((other.gameObject.tag == "Ggamy"))
        {
            //대화 시작하기
            PauseUI.SetActive(false);

        }

        else if ((other.gameObject.tag == "BadEnding"))
        {
            PauseUI.SetActive(false);
            CouponUI.SetActive(false);

        }

        else if ((other.gameObject.tag == "GoodEnding"))
        {
            PauseUI.SetActive(false);
            CouponUI.SetActive(false);

        }

    }

    void Update()
    {

        //점프
        if (Input.GetButtonDown("Jump") && (jumpCount > 0))
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
        if (Mathf.Abs(rigid.velocity.normalized.x) < 0.25)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
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
