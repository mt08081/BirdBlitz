using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure to include this namespace
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    public TMP_Text crystalCountText; // Use TMP_Text for TextMeshPro
    public int crystalCount = 0;
    

    public Button menuButton;
    public GameObject menuPanel;
    public Slider volumeSlider;
    public Button backToTitleButton;
    public Button resumeButton;

    private CanvasGroup menuPanelCanvasGroup;

    public GameObject Level;
    public GameObject ChargeController;

    public GameObject Ball;
    private Vector2 storedVelocity;
    public  Money moneyScript2;

    void Start()
    {
        UpdateCrystalCountText();

        menuButton.onClick.AddListener(ToggleMenuPanel);
        backToTitleButton.onClick.AddListener(GoBackToTitleScreen);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        resumeButton.onClick.AddListener(ToggleMenuPanel);

        menuPanelCanvasGroup = menuPanel.GetComponent<CanvasGroup>();
        HideMenuPanel();
    }

    public void IncrementCrystalCount()
    {
        crystalCount++;
        UpdateCrystalCountText();
        moneyScript2.addMoney(30);

    }

    private void UpdateCrystalCountText()
    {
        crystalCountText.text = "" + crystalCount;
    }

    public void ToggleMenuPanel()
    {
        //Debug.Log("Menu button clicked");
        if (menuPanelCanvasGroup.alpha == 0)
        {
            ShowMenuPanel();
        }
        else
        {
            HideMenuPanel();
        }
    }

    public void ShowMenuPanel()
    {
        //Debug.Log("Showing menu panel");
        menuPanelCanvasGroup.alpha = 1;
        menuPanelCanvasGroup.interactable = true;
        menuPanelCanvasGroup.blocksRaycasts = true;
        //menuPanel.SetActive(true);
        menuButton.gameObject.SetActive(false);
        Level.GetComponent<LevelController>().enabled = false;
        ChargeController.GetComponent<ChargeController>().enabled = false;
        ChargeController.GetComponent<ChargeController>().PauseGame();
        Ball.GetComponent<BallController>().enabled = false;
        Ball.GetComponent<Rigidbody2D>().gravityScale = 0;
        storedVelocity = Ball.GetComponent<Rigidbody2D>().velocity;
        Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void HideMenuPanel()
    {
        //Debug.Log("Hiding menu panel");
        menuPanelCanvasGroup.alpha = 0;
        menuPanelCanvasGroup.interactable = false;
        menuPanelCanvasGroup.blocksRaycasts = false;
        //menuPanel.SetActive(false);
        menuButton.gameObject.SetActive(true);
        Level.GetComponent<LevelController>().enabled = true;
        ChargeController.GetComponent <ChargeController>().enabled = true;
        ChargeController.GetComponent<ChargeController>().ResumeGame();
        Ball.GetComponent <BallController>().enabled = true;
        Ball.GetComponent<Rigidbody2D>().gravityScale=1;
        Ball.GetComponent<Rigidbody2D>().velocity= storedVelocity;
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
    }

    void GoBackToTitleScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
