using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject lossPanel;
    private CanvasGroup winPanelCanvasGroup;
    private CanvasGroup lossPanelCanvasGroup;

    public Button retryButtonWin;
    public Button backToTitleButtonWin;
    public Button retryButtonLoss;
    public Button backToTitleButtonLoss;

    public TMP_Text CrystalText_W;
    public TMP_Text CrystalText_L;

    private UIManager uiManager;

    void Start()
    {
        winPanelCanvasGroup = winPanel.GetComponent<CanvasGroup>();
        lossPanelCanvasGroup = lossPanel.GetComponent<CanvasGroup>();

        retryButtonWin.onClick.AddListener(RetryLevel);
        backToTitleButtonWin.onClick.AddListener(BackToTitle);
        retryButtonLoss.onClick.AddListener(RetryLevel);
        backToTitleButtonLoss.onClick.AddListener(BackToTitle);

        uiManager = FindObjectOfType<UIManager>();

        HideWinPanel();
        HideLossPanel();
    }

    public void TriggerWin()
    {
        ShowWinPanel();
        Time.timeScale = 0; // Pause the game
        CrystalText_W.text = "" + uiManager.crystalCount;
    }

    public void TriggerLoss()
    {
        ShowLossPanel();
        Time.timeScale = 0; // Pause the game
        CrystalText_L.text = "" + uiManager.crystalCount;
    }

    void ShowWinPanel()
    {
        winPanelCanvasGroup.alpha = 1;
        winPanelCanvasGroup.interactable = true;
        winPanelCanvasGroup.blocksRaycasts = true;
    }

    void HideWinPanel()
    {
        winPanelCanvasGroup.alpha = 0;
        winPanelCanvasGroup.interactable = false;
        winPanelCanvasGroup.blocksRaycasts = false;
    }

    void ShowLossPanel()
    {
        lossPanelCanvasGroup.alpha = 1;
        lossPanelCanvasGroup.interactable = true;
        lossPanelCanvasGroup.blocksRaycasts = true;
    }

    void HideLossPanel()
    {
        lossPanelCanvasGroup.alpha = 0;
        lossPanelCanvasGroup.interactable = false;
        lossPanelCanvasGroup.blocksRaycasts = false;
    }

    void RetryLevel()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void BackToTitle()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
