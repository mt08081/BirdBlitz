
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSkin : MonoBehaviour
{
    public GameObject[] skins;
    public int current_ball_index = 0;  // Initialize to 0 or any other default value
    public BallsBlueprint[] balls;
    public Money moneyScript;
    //public int moneyScript.money;
    public List<string> ownedBalls = new List<string>();  // List of owned balls
    public Button buyButton;
    public TextMeshProUGUI buyButtonText;
    public Button selectButton;
    public Select select;
    public BallsBlueprint displayImage; 


    void Start()
    {
        // Ensure the first ball is unlocked
        balls[0].unlocked = true;
        PlayerPrefs.SetInt(balls[0].name, 1);
        

        foreach (BallsBlueprint ball in balls)
        {
            if (ball.price == 0)
                ball.unlocked = true;
            else
                ball.unlocked = PlayerPrefs.GetInt(ball.name, 0) == 1;
        }

        current_ball_index = PlayerPrefs.GetInt("Selected Ball", 0);
        foreach (GameObject ball in skins)
            ball.SetActive(false);

        skins[current_ball_index].SetActive(true);

        if (buyButton != null)
        {
            buyButton.onClick.AddListener(BuyCurrentBallWrapper);
        }
        else
        {
            Debug.LogError("Buy Button is not assigned in the Inspector");
        }

        UpdateBuyButtonText(); // Initialize the buy button text
       if (selectButton != null)
        {
            selectButton.onClick.AddListener(OnSelectButtonClick);
        }
        else
        {
            Debug.LogError("Select Button is not assigned in the Inspector");
        }

    }

    public void ChangeNext()
    {
       Debug.Log("Owned balls are: " + string.Join(", ", ownedBalls));  // Corrected debug statement

        skins[current_ball_index].SetActive(false);
        current_ball_index++;
        if (current_ball_index == skins.Length)
            current_ball_index = 0;

        skins[current_ball_index].SetActive(true);

        PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
        UpdateBuyButtonText();
       // GetCharacter(current_ball_index);
    }

    public void ChangePrevious()
    {
        ownedBalls.Clear();
        skins[current_ball_index].SetActive(false);
        current_ball_index--;
        if (current_ball_index == -1)
            current_ball_index = skins.Length - 1;

        skins[current_ball_index].SetActive(true);

        PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
        UpdateBuyButtonText();
        //GetCharacter(current_ball_index);
    }

    // This wrapper method is necessary for Unity to see it in the Inspector
    public void BuyCurrentBallWrapper()
    {
        BuyCurrentBall();
    }

    private void BuyCurrentBall()
    {
        Debug.Log("Money is "+ moneyScript.money);
        BallsBlueprint currentBall = balls[current_ball_index];

        if (moneyScript != null && moneyScript.GetMoney() >= currentBall.price) // mayb add on click here
        {
            moneyScript.subtractMoney(currentBall.price);
            Debug.Log(" Ball being bought is " + currentBall.name);
            ownedBalls.Add(currentBall.name);
            Debug.Log("owned balls are " + ownedBalls);
            PlayerPrefs.SetInt(currentBall.name, 1); // Mark as owned
            Debug.Log("Bought " + currentBall.name + " for " + currentBall.price);
            UpdateBuyButtonText();  // Update the button text and state after purchase
        }
        else
        {
            Debug.Log("Not enough money to buy " + currentBall.name);
        }
    }

    void UpdateBuyButtonText()
    {
        if (buyButtonText != null && balls != null && balls.Length > 0)
        {
            BallsBlueprint currentBall = balls[current_ball_index];
            if (ownedBalls.Contains(currentBall.name)) 
            //  if (ownedBalls.Contains(currentBall.name) || currentBall.unlocked)
            {
                buyButton.interactable = false;
                buyButtonText.text = currentBall.name + " already owned";
            }
            else
            {
                if (currentBall.price == 0)
                {
                    buyButtonText.text = currentBall.name + " Free";
                }
                else
                {
                    buyButtonText.text = "Buy " + currentBall.name + " for " + currentBall.price.ToString() + " Money";
                }
                buyButton.interactable = true;
            }
        }
        else
        {
            Debug.LogError("BuyButtonText or Balls is not assigned or empty in the Inspector");
        }
    }
    public void OnSelectButtonClick()
    {
         BallsBlueprint selectedBall = balls[current_ball_index];
        if  (ownedBalls.Contains(selectedBall.name))
        {
            SpriteGen.Instance.SetSelectedBall(selectedBall);
            Debug.Log("Selected Ball: " + selectedBall.name);
        }
        else
        {
            Debug.LogWarning("Ball is not owned or does not exist.");
        }
    
    }

    public void UpdateDisplayImage()
    {
        BallsBlueprint selectedBall = balls[current_ball_index];
        if  (ownedBalls.Contains(selectedBall.name))
        {
            Debug.Log("Selected Ball: " + selectedBall.name);
            if (selectedBall != null)
            {
                displayImage.sprite = selectedBall.sprite;
                 Debug.Log(" Selected ball SPRITE  from store to go is" + selectedBall.sprite);
            }
        }

    
}
}