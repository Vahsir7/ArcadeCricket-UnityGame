using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class MatchControl : MonoBehaviour
{
    public Button one_run;
    public Button two_run;
    public Button three_run;
    public Button four_run;
    public Button five_run;
    public Button six_run;
    public Button zero_run;

    public Button ready;

    public TMP_Text batsman;
    public TMP_Text bowler;

    public TMP_Text scoreDisplay;
    public TMP_Text Overs;
    public TMP_Text teamName;
    public TMP_Text targetNeeds;

    public GameManager gameManager;
    public Timer timer;

    int ComputerRun;
    public int Totalwickets = 2;
    public int wicketsFallen = 0;
    public int score = 0;

    float overCount = 0.0f;

    public GameObject backdrop;
    public TossWindow tossWindow;

    public int target=0;
    public int inningsNo=1;


    public Image bat0;
    public Image bat1;
    public Image bat2;
    public Image bat3;
    public Image bat4;
    public Image bat5;
    public Image bat6;

    public Image ball0;
    public Image ball1;
    public Image ball2;
    public Image ball3;    
    public Image ball4;
    public Image ball5;
    public Image ball6;

    int prevRun;

    public bool Victory;

    public int[] player = new int[2];
    //public int player1;
    //public int player2;
    int count = 0;
    public void onClickOneRun(){central(1);}
    public void onClickTwoRun(){ central(2);}
    public void onClickThreeRun() { central(3);}
    public void onClickFourRun() { central (4);}
    public void onClickFiveRun() { central(5); }
    public void onClickSixRun() { central(6); }
    public void onClickZeroRun() { central(0); }

    public void matchControl()
    {
        target = 0;
        inningsNo = 1;
        overCount = 0.0f;
        score = 0;
        wicketsFallen = 0;
        Totalwickets = 2;
        scoreDisplay.text = "";
        Overs.text = "";
        teamName.text = "";
        targetNeeds.text = "";
    }
    public void refresh()
    {
        count = 0;
        player[0] = 0;
        player[1] = 0;
        inningsNo = 2;
        overCount = 0.0f;
        score = 0;
        wicketsFallen = 0;
        Totalwickets = 2;
        scoreDisplay.text = "";
        Overs.text = "";
        teamName.text = "";
        targetNeeds.text = $"Target :{target+1}";
        Start();
    }
    public void firstInnings(int run,int compRun)
    {
        Debug.Log("batmans " + run + " bowler " + compRun);
        if (run == compRun)
        {
            wicketsFallen += 1;
            count += 1;
            if (wicketsFallen == Totalwickets)
            {
                gameManager.inningsNo = 2;
                //player1 = player[0];
                //player2 = player[1];
                gameManager.matchOver();
            }
        }
        else
            player[count] += run;
            target += run;
    }
    public void secondInnings(int run, int compRun)
    {
        Debug.Log("AAAAAAAAAAAA HELP");
        if (run == compRun)
        {
            wicketsFallen += 1;
            count += 1;
            if (wicketsFallen == Totalwickets)
            {
                if (gameManager.playerWill == 0)
                    Victory = false;
                else
                    Victory = true;
                
                gameManager.inningsNo = 2;
                //player1 = player[0];
                //player2 = player[1];
                gameManager.matchOver();
            }
        }
        else
        {
            player[count] += run;
            score += run;
            if(score>=target+1)
            {
                if (gameManager.playerWill == 0)
                    Victory = true;
                else
                    Victory=false;
                gameManager.inningsNo = 2;
                gameManager.matchOver(); 
            }
        }
            
    }
    public void enabler(int run, int compRun)
    {
        bat0.enabled = false;
        bat1.enabled = false;
        bat2.enabled = false;
        bat3.enabled = false;
        bat4.enabled = false;
        bat5.enabled = false;
        bat6.enabled = false;

        ball0.enabled = false;
        ball1.enabled = false;
        ball2.enabled = false;
        ball3.enabled = false;
        ball4.enabled = false;
        ball5.enabled = false;
        ball6.enabled = false;

        switch(run)
        {
            case 0:
                bat0.enabled = true;break;
            case 1:
                bat1.enabled = true; break;
            case 2:
                bat2.enabled = true; break;
            case 3:
                bat3.enabled = true; break;
            case 4:
                bat4.enabled = true; break;
            case 5:
                bat5.enabled = true; break;
            case 6:
                bat6.enabled = true; break;
        }
        switch(compRun)
        {
            case 0:
                ball0.enabled = true; break;
            case 1:
                ball1.enabled = true; break;
            case 2:
                ball2.enabled = true; break;
            case 3:
                ball3.enabled = true; break;
            case 4:
                ball4.enabled = true; break;
            case 5:
                ball5.enabled = true; break;
            case 6:
                ball6.enabled = true; break;
        }
        /*else
        {
            switch (run)
            {
                case 0:
                    ball0.enabled = true; break;
                case 1:
                    ball1.enabled = true; break;
                case 2:
                    ball2.enabled = true; break;
                case 3:
                    ball3.enabled = true; break;
                case 4:
                    ball4.enabled = true; break;
                case 5:
                    ball5.enabled = true; break;
                case 6:
                    ball6.enabled = true; break;
            }
            switch (compRun)
            {
                case 0:
                    bat0.enabled = true; break;
                case 1:
                    bat1.enabled = true; break;
                case 2:
                    bat2.enabled = true; break;
                case 3:
                    bat3.enabled = true; break;
                case 4:
                    bat4.enabled = true; break;
                case 5:
                    bat5.enabled = true; break;
                case 6:
                    bat6.enabled = true; break;
            }
        }*/
    }
    public void central(int run)
    {
        Debug.Log("MATCH CONTROL INNINGS " + inningsNo);
        //reseting clock
        timer.remainingDuration = 7;

        //computer generated a number and if matches check
        ComputerRun = UnityEngine.Random.Range(0, 7);
        //ComputerRun = 5;

        //Debug.Log("player run" + run + " opponent run" + ComputerRun);

        
        prevRun = run;
        if (inningsNo == 1)
        {

            if (gameManager.playerWill==0)
            {
                enabler(run, ComputerRun);
                firstInnings(run, ComputerRun);
            }
                
                
            else
            {
                enabler(ComputerRun, run);
                firstInnings(ComputerRun, run);
            }
                
        }
        else
        {
            
            if (gameManager.playerWill == 0)
            {
                enabler(run, ComputerRun);
                secondInnings(run, ComputerRun);
            }
                
            else
            {
                
                enabler(ComputerRun, run);
                secondInnings(ComputerRun, run);
            }
                
        }
        //counting overs
        overCount += 0.1f;
        if (overCount - Math.Truncate(overCount) > 0.6)
            overCount = (float)Math.Ceiling(overCount);
        Overs.text = $"Overs - {overCount:0.#}";

        if(inningsNo==1)
            if (wicketsFallen != 0)
                scoreDisplay.text = $"{target}-{wicketsFallen}";
            else
                scoreDisplay.text = $"{target}-0";
        else
            if (wicketsFallen != 0)
                scoreDisplay.text = $"{score}-{wicketsFallen}";
            else
                scoreDisplay.text = $"{score}-0";
    }


    public void Start()
    {
        //Debug.Log(inningsNo);
        backdrop.SetActive(true);
        scoreDisplay.text = $"{score}-0";
        
        Overs.text = $"Overs - {overCount}";
        timer.enabled = false;
        if(inningsNo ==1 )
        {
            targetNeeds.text = "1st Innings";
        }
        else
        {
            targetNeeds.text = $"Target :{target+1}";
        }
        if(gameManager.playerWill== 0)
        {
            teamName.text = $"{tossWindow.TeamName}";
            batsman.text = "YOU";
            bowler.text = "COMP";
        }
        else
        {
            teamName.text = "COMP";
            batsman.text = "COMP";
            bowler.text = "YOU";
        }
        player[0] = 0;
        player[1] = 1;

    }
    public void onClickReady()
    {   backdrop.SetActive(false);
        timer.enabled=true;
    }
    public void Update()
    {
        if(timer.remainingDuration <= 0)
        {
            central(prevRun);
        }
    }
}
