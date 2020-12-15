using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject PauseUI;
    public GameObject SelectUI;
    public GameObject Player;
    public int spaceCount;
    public int spaceCountOld = 0;
    public int DialogSPaceCounter = -4;
    public int onceDialog = 0;
    //텍스트
    public Text talkText;
    public Text nameText;

    //이미지
    public Image OriginImage; //기존에 존재하는 이미지
    public Sprite NewSprite1; //바뀌어질 이미지 까미
    public Sprite NewSprite2; //바뀌어질 이미지 무표정
    public Sprite NewSprite3; //바뀌어질 이미지 놀란표정
    public Sprite NewSprite4; //바뀌어질 이미지 화난표정
    public Sprite NewSprite5; //페가수스
    public Sprite NewSprite6; //빼뺴로


    //사운드
    public GameObject SoundObject2;//아이템
    public GameObject SoundObject3; //나팔
    public GameObject SoundObject4; //멍멍
    public GameObject SoundObject5; //두구두구

    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
        SelectUI.SetActive(false);

    }

    public void ChangeImage(Sprite NewSprite)
    {
        OriginImage.sprite = NewSprite;
        //TestImage에 SourceImage를 TestSprite에 존재하는 이미지로 바꾸어줍니다
    }
    // Update is called once per frame
    void Update()
    {
        //대화 1
        if (onceDialog == 0)
        {
            if (Player.GetComponent<Move>().spaceCount > 7 && (Player.GetComponent<Move>().score >= 2))
            {

                PauseUI.SetActive(true);
                Time.timeScale = 0;

                //대화진행
                if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -4))
                {

                    //까미 이미지
                    ChangeImage(NewSprite1); //까미
                    nameText.text = "까미";
                    talkText.text = "...ㅋ";
                    DialogSPaceCounter++;

                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -3))
                {
                    ChangeImage(NewSprite4); //화난표정
                    nameText.text = "민수";
                    talkText.text = "웃어??? 아니 왜 안 먹어져! 게임 잘못 만든거 아냐!?";
                    DialogSPaceCounter++;

                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -2))
                {
                    //까미 이미지
                    ChangeImage(NewSprite1); //까미
                    nameText.text = "까미";
                    talkText.text = "낄낄 여기 깃발에 머리가 닿으면 동전을 주겠네.";
                    DialogSPaceCounter++;
                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -1))
                {
                    //까미 이미지
                    ChangeImage(NewSprite2); //까미
                    nameText.text = "민수";
                    talkText.text = "진짜?...";
                    DialogSPaceCounter++;
                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter >= 0))
                {
                    PauseUI.SetActive(false);
                    Time.timeScale = 1f;
                    onceDialog = 1;
                    DialogSPaceCounter = -2;

                    spaceCountOld = Player.GetComponent<Move>().spaceCount; //현재 점프 수

                }
            }
        }


        //대화 2
        else if (onceDialog == 1)
        {

            //플레이어가 10번 더 뜀
            if ((Player.GetComponent<Move>().spaceCount - spaceCountOld) >= 6)
            {

                //타이머
                PauseUI.SetActive(true);
                Time.timeScale = 0;

                if ((DialogSPaceCounter == -2))
                {
                    //까미 이미지
                    ChangeImage(NewSprite4); //표정
                    nameText.text = " ";
                    talkText.text = " ";
                    DialogSPaceCounter++;
                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -1))
                {
                    //까미 이미지
                    ChangeImage(NewSprite4); //표정
                    nameText.text = "민수";
                    talkText.text = "뭐야? 게임 꺼버릴래.";
                    DialogSPaceCounter++;
                }


                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 0))
                {
                    //까미 이미지
                    ChangeImage(NewSprite1); //까미
                    nameText.text = "까미";
                    talkText.text = "낄낄 미안하네. 장난은 그만 치겠네.";
                    DialogSPaceCounter++;
                }
                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 1))
                {
                    talkText.text = "마침 줄 것이 있네. 한비가 주라더군...";
                    DialogSPaceCounter++;

                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 2))
                {
                    ChangeImage(NewSprite5); //페가수스 
                    nameText.text = " ";
                    talkText.text = "[페가수스를 얻었습니다.]";
                    DialogSPaceCounter++;

                    //소리나게 하기
                    SoundObject2.GetComponent<AudioSource>().Play();
                    
                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 3))
                {
                    ChangeImage(NewSprite3); //민수 
                    nameText.text = "민수";
                    talkText.text = "호엑! 수스형!";
                    DialogSPaceCounter++;

                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 4))
                {
                    ChangeImage(NewSprite1); //까미
                    nameText.text = "까미";
                    talkText.text = "좀 더 잘 뛸 수 있을걸세. 껄껄~ 동전을 모아오라고.";
                    DialogSPaceCounter++;

                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 5))
                {
                    ChangeImage(NewSprite5); //까미
                    nameText.text = " ";
                    talkText.text = "[점프력이 +5 증가했습니다!]";
                    DialogSPaceCounter++;

                    Player.GetComponent<Move>().setJumpPower(1.5f);

                    //소리나게 하기
                    SoundObject3.GetComponent<AudioSource>().Play();

                }

                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 6))
                {
                    ChangeImage(NewSprite2); //무표정
                    nameText.text = "민수";
                    talkText.text = "내 페가수스 닳면 어쩌지? 가지고만 있어야겠다... ㅜㅜ";
                    DialogSPaceCounter++;

                }


                else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter >= 7))
                {

                    PauseUI.SetActive(false);
                    Time.timeScale = 1f;
                    onceDialog = 2;
                    DialogSPaceCounter = -3;

                }
            }
        }

        
                //대화3 
                //플레이어가 동전을 다 모아옴
                else if (onceDialog == 2)
                {
                    if (Player.GetComponent<Move>().score >= 24)
                    {
                        //타이머
                        Time.timeScale = 0;

                        PauseUI.SetActive(true);


                        if ((DialogSPaceCounter == -3))
                        {
                            ChangeImage(NewSprite2); //무표정
                            nameText.text = "민수";
                            talkText.text = "이지이이이 EZ";
                            DialogSPaceCounter++;

                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -2))
                        {
                            //까미 이미지
                            ChangeImage(NewSprite1); //까미
                            nameText.text = "까미";
                            talkText.text = "자네 생각보다 빨리 했군? 약속대로 특별한 빼빼로를 주지.";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -1))
                        {
                            ChangeImage(NewSprite3);
                            nameText.text = "민수";
                            talkText.text = "줄건 줘야지~";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 0))
                        {
                            ChangeImage(NewSprite1); //까미
                            nameText.text = "까미";
                            talkText.text = "껄껄 알았다네. 여기 있네.";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 1))
                        {

                            ChangeImage(NewSprite1); //까미
                            nameText.text = "까미";
                            talkText.text = ".............좀 기다리게!";
                            DialogSPaceCounter++;

                            //소리나게 하기
                            SoundObject5.GetComponent<AudioSource>().Play();

                        }


                        else if (Input.GetButtonDown("Jump")&&(DialogSPaceCounter == 2))
                        {                    
                            //타이머
                            ChangeImage(NewSprite6);
                            nameText.text = " ";
                            talkText.text = "[매우 특별한 빼빼로를 얻었습니다!]";
                            DialogSPaceCounter++;

                            //소리나게 하기
                            SoundObject2.GetComponent<AudioSource>().Play();


                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 3))
                        {
                            ChangeImage(NewSprite2);
                            nameText.text = "민수";
                            talkText.text = ".............음...?";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 4))
                        {
                            ChangeImage(NewSprite1);
                            nameText.text = "까미";
                            talkText.text = "그걸로 뭘 할 건지는 정했는가?";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 5))
                        {
                            ChangeImage(NewSprite3);
                            nameText.text = "민수";
                            talkText.text = "받으면 받은거지 뭘 해?";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 6))
                        {
                            ChangeImage(NewSprite1);
                            nameText.text = "까미";
                            talkText.text = "자네는 선택해야 하네.";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 7))
                        {
                            ChangeImage(NewSprite2);
                            nameText.text = "민수";
                            talkText.text = "먹을까? 아니면 빼빼로데이인데 한비 줄까?";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 8))
                        {
                            ChangeImage(NewSprite4);
                            nameText.text = "민수";
                            talkText.text = "맛있게 생겼는데... 마침 배곱띠하고...";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 9))
                        {
                            ChangeImage(NewSprite2);
                            nameText.text = "민수";
                            talkText.text = "진짜 그냥 먹어버릴까?";
                            DialogSPaceCounter++;
                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 10))
                        {
                            ChangeImage(NewSprite2);
                            nameText.text = "민수";
                            talkText.text = "어쩌지?";
                            DialogSPaceCounter++;

                        }

                        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 11))
                        {

                            //새 캔버스 - 선택 버튼 보이기
                             //대화창 숨기기 
                                   Time.timeScale = 1f;
                    //캐릭터 못움직이게 하기
                    Player.GetComponent<Move>().enabled = false;

                    onceDialog = 3;
                                   PauseUI.SetActive(false);
                                   SelectUI.SetActive(true);
                                    DialogSPaceCounter++;

                        }



            }

        }
    }






}
