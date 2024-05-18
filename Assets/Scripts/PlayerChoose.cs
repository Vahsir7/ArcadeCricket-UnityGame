using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoose : MonoBehaviour
{
    public Button batting;
    public Button bowling;

    public GameManager gameManager;
    public void onCLickBatting()
    {
        gameManager.matchSetting(0);
        gameManager.matchStart();
    }
    public void onCLickBowling()
    {
        gameManager.matchSetting(1);
        gameManager.matchStart();
    }
}
