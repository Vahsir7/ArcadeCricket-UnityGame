using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreCard : MonoBehaviour
{
    public TMP_Text header;
    public TMP_Text teamName1;
    public TMP_Text Score1;
    public TMP_Text Players1;
    public TMP_Text Players2;
    public TMP_Text score2;
    public TMP_Text teamName2;
    public TMP_Text PlayerNeeds;
    public TMP_Text endMessage;

    public GameObject resume;
    public GameObject exit;
    //public GameObject replay;

    public GameManager gameManager;
    public MatchControl matchControl;
    public TossWindow tossWindow;
    public int inningsNo = 2;
    
    public void OnEnable()
    {
        inningsNo = gameManager.inningsNo;
        //inningsNo = 2;
        //header
        Debug.Log("I AM IN SCORECARD my innings is " + inningsNo);
        if (inningsNo == 1)
        {
            Debug.Log("i am in if block");
            Players2.enabled = false;
            score2.enabled = false;
            teamName2.enabled = false;
            exit.SetActive(false);
            //replay.SetActive(false);
            resume.SetActive(true);
            header.text = "End of first innings";

            if (gameManager.playerWill == 0)
            {
                teamName1.text = $"{tossWindow.TeamName}";
                PlayerNeeds.text = $"COMP needs {matchControl.target + 1} runs to win";
            }

            else
            {
                teamName1.text = "COMP";
                PlayerNeeds.text = $"{tossWindow.TeamName} needs {matchControl.target + 1} runs to win";
            }

            Score1.text = $"{matchControl.target}-{matchControl.wicketsFallen}";
            Players1.text = $"Player 1\t {matchControl.player[0]}\nPlayer 2\t {matchControl.player[1]}";

            endMessage.enabled = false;
            gameManager.playerWill = (gameManager.playerWill == 0) ? 1 : 0;
        }
        else
        {
            Debug.Log("i am in else block");
            Players2.enabled = true;
            score2.enabled = true;
            teamName2.enabled = true;

            endMessage.enabled = true;

            resume.SetActive(false);
            //replay.SetActive(true);
            exit.SetActive(true);
            header.text = "End of second innings";
            if (gameManager.playerWill == 0)
                teamName2.text = $"{tossWindow.TeamName}";

            else
                teamName2.text = "COMP";
            score2.text = $"{matchControl.score}-{matchControl.wicketsFallen}";
            Players2.text = $"Player 1\t {matchControl.player[0]}\nPlayer 2\t {matchControl.player[1]}";
            if (matchControl.Victory == true)
                endMessage.text = $"{tossWindow.TeamName} has won";
            else
                endMessage.text = $"{tossWindow.TeamName} has lost";
        }
    }
    
    public void onClickResume()
    {
        
        gameManager.matchStart();
        matchControl.refresh();
    }
    public void onClickExit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    /*public void onClickReplay()
    {
        matchControl.matchControl();
        gameManager.Start();
    }*/

}
