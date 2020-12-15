using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RetryButton()
    {
        SceneManager.LoadScene("StartGame");
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("BadEnding", 1); //배드엔딩 회수
        PlayerPrefs.Save();
        /*PlayerPrefs.GetInt("키이름");*/
    }


}
