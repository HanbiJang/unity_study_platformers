using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ByEndingStartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

       /* PlayerPrefs.DeleteAll();*/
        if (PlayerPrefs.GetInt("GiveEnding") == 1)
        {
            //give엔딩 봤으면 시작화면 바꾸기
            SceneManager.LoadScene("StartGameAdd");
            Time.timeScale = 1f;

        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
