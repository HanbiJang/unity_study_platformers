using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject PauseUI; //대화창
    public GameObject MainMenuUI;
    public int DialogSPaceCounter = -4;
    //텍스트
    public Text talkText;
    public Text nameText;
    //크레딧
    public GameObject creditImege;
    //소리
    public GameObject SoundObject;
    public GameObject SoundObject1; //빠밤
    public GameObject SoundObject2; //예야

    //이미지
    public Image OriginImage; //기존에 존재하는 이미지
    public Sprite NewSprite1; //바뀌어질 이미지 까미
    public Sprite NewSprite2; //바뀌어질 이미지 무표정
    public Sprite NewSprite3; //바뀌어질 이미지 놀란표정
    public Sprite NewSprite4; //바뀌어질 이미지 화난표정
    public Sprite NewSprite5; //바뀌어질 이미지 한비
    public Sprite NewSprite6; //바뀌어질 이미지 빼뺴로


    // Start is called before the first frame update
    void Start()
    {
        MainMenuUI.SetActive(false);
        creditImege.SetActive(false);
    }
    public void ChangeImage(Sprite NewSprite)
    {
        OriginImage.sprite = NewSprite;
        //TestImage에 SourceImage를 TestSprite에 존재하는 이미지로 바꾸어줍니다
    }
    // Update is called once per frame
    void Update()
    {
        PauseUI.SetActive(true); //대화 보이기

        if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -4))
        {
            ChangeImage(NewSprite5);
            nameText.text = "한비";
            talkText.text = "..........";
            DialogSPaceCounter++;
        }
        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -3))
        {
            ChangeImage(NewSprite5);
            nameText.text = "한비";
            talkText.text = "........얘야. 인생이란 원래 자기 생각대로 되지 않는 법이란다..";
            DialogSPaceCounter++;

            //소리나게 하기
            SoundObject2.GetComponent<AudioSource>().Play();
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -2))
        {
            ChangeImage(NewSprite4);
            nameText.text = "민수";
            talkText.text = "아악! 구만해!!!";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == -1))
        {
            ChangeImage(NewSprite3);
            nameText.text = "민수";
            talkText.text = "오늘이 무슨 날인지 알아 한비?";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 0))
        {
            ChangeImage(NewSprite5);
            nameText.text = "한비";
            talkText.text = "모르겠는딤";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 1))
        {
            ChangeImage(NewSprite3);
            nameText.text = "민수";
            talkText.text = "빼빼로 데이얌!";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 2))
        {
            ChangeImage(NewSprite3);
            nameText.text = "민수";
            talkText.text = "빼빼로 데이얌! 자 여기 특별한 빼빼로야!";
            DialogSPaceCounter++;
        }



        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 3))
        {
            ChangeImage(NewSprite6);
            nameText.text = " ";
            talkText.text = "[영롱한 빼빼로들]";
            DialogSPaceCounter++;

            //빠밤 소리
            //소리나게 하기
            SoundObject1.GetComponent<AudioSource>().Play();
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 4))
        {
            ChangeImage(NewSprite5);
            nameText.text = "한비";
            talkText.text = "호에엑! 고마웡 민수 잘 먹을겡!!";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 5))
        {
            ChangeImage(NewSprite2);
            nameText.text = "민수";
            talkText.text = "ㅎㅎㅎㅎㅎㅎ";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 6))
        {
            ChangeImage(NewSprite5);
            nameText.text = "한비";
            talkText.text = "옴냠냠";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 7))
        {
            ChangeImage(NewSprite2);
            nameText.text = "민수";
            talkText.text = "ㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎ";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 8))
        {
            ChangeImage(NewSprite3);
            nameText.text = "민수";
            talkText.text = "ㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎㅎ";
            DialogSPaceCounter++;
        }

        else if (Input.GetButtonDown("Jump") && (DialogSPaceCounter == 9))
        {
            ChangeImage(NewSprite2);
            nameText.text = "민수";
            talkText.text = "근디 내껀?";

            //시간 차 순서대로 실행
            //4초 후에 바로 엔딩 크레딧 나오기
            //22초 기다린 다음에 UI로 대화 , 새로운 메인 메뉴로 가는 버튼 생성하기
            StartCoroutine(WaitForIt());
        }

    }

    IEnumerator WaitForIt()
    {
        DialogSPaceCounter = 10;
        yield return new WaitForSecondsRealtime(1f);
        PauseUI.SetActive(false);
        //엔딩 크레딧 띄우기
        Time.timeScale = 1f;
        creditImege.SetActive(true);

        //22초 기다리기
        yield return new WaitForSecondsRealtime(18f);
        DialogSPaceCounter = 11;

        if ((DialogSPaceCounter == 11))
        {
            creditImege.SetActive(false);
            ChangeImage(NewSprite5);
            nameText.text = "한비";
            talkText.text = "<color=#ff0000>" + "비밀의 신전" + "</color>" + "으로 들어왕 ";
            Time.timeScale = 1f;
            yield return new WaitForSecondsRealtime(3f);


            nameText.text = "한비";
            talkText.text = "비밀 번호는 " + "<color=#ff0000>" + "우리가 만난 날" + "</color>" + "이야♡";
            DialogSPaceCounter++;
            PlayerPrefs.SetInt("GiveEnding", 1); //해피엔딩 회수
            PlayerPrefs.Save();
            yield return new WaitForSecondsRealtime(3f);

            //UI 띄우기
            MainMenuUI.SetActive(true);
        }


       }

    public void MainMenuButton()
    {
        //버튼 누르는 소리
        SoundObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("StartGameAdd");
        Time.timeScale = 1f;

    }

}



