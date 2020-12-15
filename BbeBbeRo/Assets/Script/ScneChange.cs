using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScneChange : MonoBehaviour
{
    public GameObject InputUI;
    public InputField inputField;
    public Text inputText;
    public AudioSource SoundObject;
    private void Update()
    {

        //비밀번호가 맞으면 들어갈 수 있음
        if (inputText.text.Equals("20181225") )
        {
            //사운드 정답 사운드
            SoundObject.GetComponent<AudioSource>().Play();

            SceneManager.LoadScene("BoneGame_bimil", LoadSceneMode.Single);
            Time.timeScale = 1f;
        }

    }

    public void ChangeBoneGameScene()
    {

        SceneManager.LoadScene("BoneGame_Daehwa", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void BoneGameAddSceneBefore()
    {

        //ui 띄우기
        InputUI.SetActive(true);


/*        SceneManager.LoadScene("BoneGame_bimil", LoadSceneMode.Single);
        Time.timeScale = 1f;*/
    }

}
