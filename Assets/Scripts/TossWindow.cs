using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TossWindow : MonoBehaviour
{
    // Start is called before the first frame update

    public Button headsButton;
    public Button tailsButton;
    public Button SaveButton;
    public TMP_InputField teamNameInput;

    public GameManager gameManager;

    public string TeamName;

    void Start()
    {
        teamNameInput.text = "";
        // Disable both buttons at the start
        headsButton.interactable = false;
        tailsButton.interactable = false;
        //SaveButton.interactable = true;
    }
    public void ReadInput(string s)
    {
        TeamName = s;
        Debug.Log(TeamName);
    }

    public void OnSaveButtonClicked()
    {
        // Check if the input field has some text
        if (!string.IsNullOrEmpty(teamNameInput.text))
        {
            // Enable both buttons
            headsButton.interactable = true;
            tailsButton.interactable = true;
            SaveButton.interactable = false;
        }
    }
    public void OnHeadsButtonClicked()
    {
        gameManager.toss(0); // Pass 1 (Heads) to GameManager
    }

    public void OnTailsButtonClicked()
    {
        gameManager.toss(1); // Pass 0 (Tails) to GameManager
    }

}

