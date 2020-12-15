using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealSelectEndingButton : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectEatEnding()
    {
        SceneManager.LoadScene("EatEnding");
        Time.timeScale = 1f;
        Player.GetComponent<Move>().enabled = true;
    }

    public void SelectGiveEnding()
    {
        SceneManager.LoadScene("GiveEnding");
        Time.timeScale = 1f;
        Player.GetComponent<Move>().enabled = true;
    }
}
