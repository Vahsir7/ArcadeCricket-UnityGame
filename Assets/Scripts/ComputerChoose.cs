using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerChoose : MonoBehaviour
{
    public GameObject batting;
    public GameObject bowling;

    public GameManager gameManager;

    public Button playButton;
    int randomResult;

    public void Start()
    {
        randomResult = Random.Range(0, 2);
        //Debug.Log(randomResult);
        if(randomResult == 0 )
        {
            //batting.enabled = false;
            //bowling.enabled = true;
            batting.SetActive(false);
            bowling.SetActive(true);
        }    
        else
        {
            //batting.enabled=true;
            //bowling.enabled=false;
            batting.SetActive(true);
            bowling.SetActive(false);
        }

    }
    public void resume()
    {
        if (playButton.interactable)
        {
            gameManager.matchSetting(randomResult);
                gameManager.matchStart();
        }
    }
}
