using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonSound : MonoBehaviour
{

    public bool oncePlayed = false;
    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame() {

        if (oncePlayed == false) {

            AudioSource playButton1 = playButton.GetComponent<AudioSource>();
            playButton1.Play();

            oncePlayed = true;
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
