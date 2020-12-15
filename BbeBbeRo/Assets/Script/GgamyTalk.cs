using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GgamyTalk : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject BadEnding;
    public GameObject GoodEnding;


    private void OnGUI()
    {
        GUILayout.Label("나가기: Esc / 상호작용: 스페이스바");
    }
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);


    }



    // Update is called once per frame
    void Update()
    {

        //배드 엔딩 깨지 않았으면 비활성화
        if (PlayerPrefs.GetInt("BadEnding")==0) {
            BadEnding.SetActive(false);

            
        }



        if (Input.GetButtonDown("Cancel")) {

            SceneManager.LoadScene("StartGameAdd", LoadSceneMode.Single);
            Time.timeScale = 1f;
        }
        
    }
}
