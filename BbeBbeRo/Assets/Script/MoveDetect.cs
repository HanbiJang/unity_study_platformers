using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MoveDetect : MonoBehaviour
{

    public GameObject Player;
   
    Rigidbody2D rigid;  //Rigidbody2D -변수명 rigid 선언 
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float jumpPower;
    public int jumpCount = 2;
    public bool onceLanding = false;
    public int spaceCounter = -4 ;
    //텍스트
    public Text talkText;
    public Text nameText;

    //이미지
    public Image OriginImage; //기존에 존재하는 이미지
    public Sprite NewSprite1; //바뀌어질 이미지 까미
    public Sprite NewSprite2; //바뀌어질 이미지 무표정
    public Sprite NewSprite3; //바뀌어질 이미지 놀란표정
    public Sprite NewSprite4; //바뀌어질 이미지 화난표정

    //사운드
    public GameObject SoundObject1;//멍멍 소리
    public GameObject SoundObject2;//드랍 소리



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //rigid 변수 초기화
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //이미지 변환 함수
    public void ChangeImage(Sprite NewSprite)
    {
        OriginImage.sprite = NewSprite;
        //TestImage에 SourceImage를 TestSprite에 존제하는 이미지로 바꾸어줍니다
    }

    private void Start()
    {
    }

    void Update()
    {

        if ((spaceCounter == -4))
        {
            nameText.text = " ";
            talkText.text = "(대화 진행 : "+ "<color=#ff0000>" + "스페이스바)" + "</color>";
            spaceCounter++;

        }

        if (Input.GetButtonDown("Jump") && (spaceCounter == -3)) {
            ChangeImage(NewSprite3); //놀란표정
            nameText.text = "민수";
            talkText.text = "아야! 여긴 어디지?";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == -2))
        {
            /*            SceneManager.LoadScene("BoneGame"); 대화 끝나면 플레이 화면으로 전환*/
            //까미 이미지
            ChangeImage(NewSprite1); //까미
            nameText.text = "???";
            talkText.text = "정신이 드나. 인간?";
            spaceCounter++;

            //소리나게 하기
            SoundObject1.GetComponent<AudioSource>().Play();
        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == -1))
        {
            /*            SceneManager.LoadScene("BoneGame"); 대화 끝나면 플레이 화면으로 전환*/
            //까미 이미지
            ChangeImage(NewSprite2); //표정
            nameText.text = "민수";
            talkText.text = "넌 무야!";
            spaceCounter++;
        }


        else if (Input.GetButtonDown("Jump") && (spaceCounter == 0))
        {
            /*            SceneManager.LoadScene("BoneGame"); 대화 끝나면 플레이 화면으로 전환*/
            //까미 이미지
            ChangeImage(NewSprite1); //까미
            nameText.text = "???";
            talkText.text = "여기는 픽셀의 세계라네...";
            spaceCounter++;
        }
        else if (Input.GetButtonDown("Jump") && (spaceCounter == 1)) {
            nameText.text = "까미";
            talkText.text = "나는 까미... 오늘은 특별한 날이라네.";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 2))
        {
            talkText.text = "한비가 기다리는 날이었군.";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 3))
        {
            talkText.text = "확실히 " + "<color=#ff0000>" + "빼빼로 데이" + "</color>" + "였지.";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 4))
        {
            ChangeImage(NewSprite3); //놀란표정
            nameText.text = "민수";
            talkText.text = "헉... 큰일이다. 완전 까먹고 있었다.";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 5))
        {
            ChangeImage(NewSprite1); //까미
            nameText.text = "까미";
            talkText.text = "이봐, 젊은 친구. 걱정말게.";
            spaceCounter++;


        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 6))
        {
            talkText.text = "저 동전들을 모두 모아오면,";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 7))
        {
            talkText.text = "저 동전들을 모두 모아오면, " + "<color=#ff0000>" + "특별한 빼빼로" + "</color>" +"를 주겠네.";
            spaceCounter++;


            //소리나게 하기
            SoundObject1.GetComponent<AudioSource>().Play();

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 8))
        {
            talkText.text = "<color=#ff0000>" + "동전" + "</color>"+"을 모아오게나.";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 9))
        {
            ChangeImage(NewSprite4); //화난표정
            nameText.text = "민수";
            talkText.text = "흠냐... 알겠어!";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 10))
        {
            ChangeImage(NewSprite2); //무표정
            nameText.text = " ";
            talkText.text = "<color=#ff0000>" + "[방향키: ←→ / 점프: 스페이스바]" + "</color>";
            spaceCounter++;

        }

        else if (Input.GetButtonDown("Jump") && (spaceCounter == 11))
        {

            SceneManager.LoadScene("BoneGame");
            Time.timeScale = 1f;

        }



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

                if (rayHit.distance <= 0.28f && (onceLanding == false))
                {
                    //착지하면 효과음 내기
                    //소리나게 하기
                    SoundObject2.GetComponent<AudioSource>().Play();
                    onceLanding = true;

                }

            }


        }

    }
}
