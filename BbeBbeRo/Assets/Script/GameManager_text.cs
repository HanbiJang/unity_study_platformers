using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_text : MonoBehaviour
{

    public Text talkText;
    public GameObject scanObject;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Action(GameObject scanObj) {

        scanObject = scanObj;
        talkText.text = "이름은" + scanObject.name + "라고 한다";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
