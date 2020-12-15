using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectEnding_Button : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject BigPigUI;
    public int clickNum = 0;
    public Image OriginImage; //기존에 존재하는 이미지
    public Sprite NewSprite1; //바뀌어질 이미지 까미
    public Sprite NewSprite2; //바뀌어질 이미지 무표정
    public Sprite NewSprite3; //바뀌어질 이미지 놀란표정
    public Sprite NewSprite4; //바뀌어질 이미지 화난표정
    public Sprite NewSprite5; //바뀌어질 이미지 돼지흑
    public Sprite NewSprite6; //바뀌어질 이미지 돼지원본

    public GameObject SoundObject;//어흥소리
    //대사 순서
    public int DialogSPaceCounter = -4;
    //텍스트
    public Text talkText;
    public Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
        BigPigUI.SetActive(false);

    }

    public void ChangeImage(Sprite NewSprite)
    {
        OriginImage.sprite = NewSprite;
        //TestImage에 SourceImage를 TestSprite에 존재하는 이미지로 바꾸어줍니다
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            clickNum++;
        }


        if (clickNum > 4) { //6번 클릭시

            //대화진행
            if ((DialogSPaceCounter == -4))
            {
                PauseUI.SetActive(true);

                //까미 이미지
                /*                ChangeImage(NewSprite1); //까미*/
                nameText.text = "민수";
                talkText.text = ".........?";
                DialogSPaceCounter++;

            }
            else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -3))
            {
                nameText.text = "민수";
                talkText.text = "뭐야?";
                DialogSPaceCounter++;

            }

            else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -2))
            {
                ChangeImage(NewSprite2);
                nameText.text = "민수";
                talkText.text = "뭐야 이거? 끝이야? ";
                DialogSPaceCounter++;

            }

            else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -1))
            {
                ChangeImage(NewSprite5);
                nameText.text = "???";
                talkText.text = "또 누가 왔지?";
                DialogSPaceCounter++;

            }

            else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 0))
            {
                ChangeImage(NewSprite3);
                nameText.text = "민수";
                talkText.text = "누구세요? 여긴 뭐하는 곳인가요.";
                DialogSPaceCounter++;

            }

            else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 1))
            {
                ChangeImage(NewSprite5);
                nameText.text = "???";
                talkText.text = "나의 이름은 BadKindMinSooTaeYoungIkGyu";
                DialogSPaceCounter++;

            }

            else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 2))
            {
                ChangeImage(NewSprite5);
                nameText.text = "???";
                talkText.text = "식탐의 신이다.";
                DialogSPaceCounter = 3 ;

            }

            else if ((DialogSPaceCounter == 3))
            {
                StartCoroutine(WaitForIt());
                DialogSPaceCounter = 4;
            }




        }


    }


    IEnumerator WaitForIt()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        BigPigUI.SetActive(false);
        ChangeImage(NewSprite6);
        nameText.text = "BadKindMinSooTaeYoungIkGyu";
        talkText.text = "그리고 뇌절의 신이지. 넌 끝났다.";

        yield return new WaitForSecondsRealtime(0.7f);

        //돼지 사운드 재생
        //소리나게 하기
        SoundObject.GetComponent<AudioSource>().Play();

        BigPigUI.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        //화면 넘기기
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1f;
    }




}
