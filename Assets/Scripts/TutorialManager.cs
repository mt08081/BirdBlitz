using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject pressAndHoldPanel;
    public GameObject dodgeSpikesPanel;
    public GameObject goodLuckPanel;
    public GameObject jumpLevel;
    public GameObject level;
    public BallController ballController;

    private int jumpCount = 0;
    private bool tutorialComplete = false;

    void Start()
    {
        // Initial setup
        ShowPressAndHoldPanel();
    }

    void ShowPressAndHoldPanel()
    {
        pressAndHoldPanel.SetActive(true);
        dodgeSpikesPanel.SetActive(false);
        goodLuckPanel.SetActive(false);
        jumpLevel.SetActive(true);
        level.SetActive(false);
        //ballController.enabled = false;
    }

    void ShowDodgeSpikesPanel()
    {
        pressAndHoldPanel.SetActive(false);
        dodgeSpikesPanel.SetActive(true);
        goodLuckPanel.SetActive(false);
        jumpLevel.SetActive(false);
        level.SetActive(true);
        //ballController.enabled = false;
    }

    void ShowGoodLuckPanel()
    {
        pressAndHoldPanel.SetActive(false);
        dodgeSpikesPanel.SetActive(false);
        goodLuckPanel.SetActive(true);
        jumpLevel.SetActive(false);
        level.SetActive(false);
        //ballController.enabled = false;
    }

    void Update()
    {
        // Handle the input and state transitions
        if (pressAndHoldPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            StartJumpLevel();
        }
        else if (dodgeSpikesPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            StartLevel();
        }
        else if (goodLuckPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            ReturnToLevelSelector();
        }

        if (jumpCount >= 3 && jumpLevel.activeSelf)
        {
            StartDodgeSpikesPhase();
        }

        if (tutorialComplete)
        {
            ShowGoodLuckPanel();
        }
    }

    void StartJumpLevel()
    {
        pressAndHoldPanel.SetActive(false);
        //ballController.enabled = true;
    }

    void StartDodgeSpikesPhase()
    {
        //ballController.enabled = false;
        ShowDodgeSpikesPanel();
    }

    void StartLevel()
    {
        dodgeSpikesPanel.SetActive(false);
        ballController.enabled = true;
    }

    public void OnPlayerFailed()
    {
        ShowDodgeSpikesPanel();
    }

    public void OnPlayerSucceeded()
    {
        tutorialComplete = true;
    }

    void ReturnToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void IncrementJumpCount()
    {
        jumpCount++;
    }
}
