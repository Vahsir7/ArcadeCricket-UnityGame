using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TossScreen;
    public GameObject WonTossScreen;
    public GameObject LostTossScreen;
    public GameObject PlayGroundScreen;
    public GameObject scoreCard;

    public int playerWill;

    public MatchControl matchcontrol;
    public Timer timer;
    public scoreCard scoreCardObject;
    public bool activateReplay=false;
    public int inningsNo=1;

    public AudioManager audioManager;
    //public AudioSource audioSource;

    public AudioClip title;
    public AudioClip IPL;
    
    

    public void Start()
    {
        audioManager.Play(title);
        Debug.Log("title play");
        TossScreen.SetActive(true);

        WonTossScreen.SetActive(false);
        LostTossScreen.SetActive(false);
        PlayGroundScreen.SetActive(false);
        scoreCard.SetActive(false);
        scoreCardObject.enabled = false;

    }
    public void toss(int tossResult)
    {
        // Generate a random number between 0 and 1
        int randomResult = Random.Range(0, 2);
        Debug.Log("player chose" + tossResult + " and the outcome is " + randomResult);
        if (randomResult == tossResult)
        {
            // Toss is won
            TossScreen.SetActive(false);
            WonTossScreen.SetActive(true);
            LostTossScreen.SetActive(false);
            PlayGroundScreen.SetActive(false);
            scoreCard.SetActive(false);
        }
        else
        {
            // Toss is lost
            TossScreen.SetActive(false);
            WonTossScreen.SetActive(false);
            LostTossScreen.SetActive(true);
            PlayGroundScreen.SetActive(false);
            scoreCard.SetActive(false);
        }
    }
    public void matchSetting(int humanMode)
    {
        if(humanMode == 0)
        {
            playerWill=0;
        }
        else
        {
            playerWill=1;
        }
    }

    public void matchStart()
    {
        audioManager.audioSource.Stop();
        audioManager.Play(IPL);
        TossScreen.SetActive(false);
        WonTossScreen.SetActive(false);
        LostTossScreen.SetActive(false);
        PlayGroundScreen.SetActive(true);
        scoreCard.SetActive(false);
        Debug.Log("IPL play");
    }    

    public void matchOver()
    {
        audioManager.audioSource.Stop();
        audioManager.Play(title);
        if (matchcontrol.inningsNo==1) 
        {
            Debug.Log("GAMEMANAGER innings " + inningsNo);
            scoreCard.SetActive(true);
            inningsNo = 1;
            scoreCardObject.enabled = true;
            //scoreCardObject.launch(1);

            TossScreen.SetActive(false);
            WonTossScreen.SetActive(false);
            LostTossScreen.SetActive(false);
            PlayGroundScreen.SetActive(false);

            timer.enabled = false;
            //playerWill = (playerWill==0) ? 1 : 0;

        }
        else if(matchcontrol.inningsNo==2)
        {
            Debug.Log("GAMEMANAGER inn" + inningsNo);
            scoreCard.SetActive(true);
            //scoreCardObject.launch(2);
            inningsNo = 2;
            scoreCardObject.enabled = true;
            TossScreen.SetActive(false);
            WonTossScreen.SetActive(false);
            LostTossScreen.SetActive(false);
            PlayGroundScreen.SetActive(false);

            timer.enabled = false;   
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
