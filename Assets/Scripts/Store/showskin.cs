// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ShowSkin : MonoBehaviour
// {
//     public GameObject[] skins;
//     public int current_ball_index = 0;
//     public BallsBlueprint[] balls;
//     public Money moneyScript;
//     public List<string> ownedBalls = new List<string>();
//     public Button buyButton;
//     public TextMeshProUGUI buyButtonText;
//     public Button selectButton;
//     public Select select;
//     public BallsBlueprint displayImage;
//     public TMP_Text crystalText;

//     void Start()
//     {
//         balls[0].unlocked = true;
//         PlayerPrefs.SetInt(balls[0].name, 1);

//         foreach (BallsBlueprint ball in balls)
//         {
//             if (ball.price == 0)
//                 ball.unlocked = true;
//             else
//                 ball.unlocked = PlayerPrefs.GetInt(ball.name, 0) == 1;
//         }

//         current_ball_index = PlayerPrefs.GetInt("Selected Ball", 0);
//         foreach (GameObject ball in skins)
//             ball.SetActive(false);

//         skins[current_ball_index].SetActive(true);

//         // if (buyButton != null)
//         // {
//         //     buyButton.onClick.RemoveAllListeners(); // Clear any existing listeners
//         //     buyButton.onClick.AddListener(BuyCurrentBallWrapper);
//         // }
//         // else
//         // {
//         //     Debug.LogError("Buy Button is not assigned in the Inspector");
//         // }

//         UpdateBuyButtonText();

//         if (selectButton != null)
//         {
//             selectButton.onClick.RemoveAllListeners(); // Clear any existing listeners
//             selectButton.onClick.AddListener(OnSelectButtonClick);
//         }
//         else
//         {
//             Debug.LogError("Select Button is not assigned in the Inspector");
//         }
//     }

//     void Update()
//     {
//         crystalText.text = "" + moneyScript.money;
//     }

//     public void ChangeNext()
//     {
//         Debug.Log("Owned balls are: " + string.Join(", ", ownedBalls));

//         skins[current_ball_index].SetActive(false);
//         current_ball_index++;
//         if (current_ball_index == skins.Length)
//             current_ball_index = 0;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);
//         UpdateBuyButtonText();
//     }

//     public void ChangePrevious()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index--;
//         if (current_ball_index == -1)
//             current_ball_index = skins.Length - 1;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);
//         UpdateBuyButtonText();
//     }

//     public void BuyCurrentBallWrapper()
//     {
//         Debug.Log("BuyCurrentBallWrapper called");
//         BuyCurrentBall();
//     }

//     private void BuyCurrentBall()
//     {
//         Debug.Log("BuyCurrentBall called");
//         Debug.Log("Money is " + moneyScript.money);
//         BallsBlueprint currentBall = balls[current_ball_index];

//         if (moneyScript != null && moneyScript.GetMoney() >= currentBall.price)
//         {
//             moneyScript.subtractMoney(currentBall.price);
//             Debug.Log("Ball being bought is " + currentBall.name);
//             ownedBalls.Add(currentBall.name);
//             PlayerPrefs.SetInt(currentBall.name, 1);
//             Debug.Log("Bought " + currentBall.name + " for " + currentBall.price);
//             UpdateBuyButtonText();
//         }
//         else
//         {
//             Debug.Log("Not enough money to buy " + currentBall.name);
//         }
//     }

//     void UpdateBuyButtonText()
//     {
//         if (buyButtonText != null && balls != null && balls.Length > 0)
//         {
//             BallsBlueprint currentBall = balls[current_ball_index];
//             if (ownedBalls.Contains(currentBall.name))
//             {
//                 buyButton.interactable = false;
//                 buyButtonText.text = currentBall.name + " already owned";
//             }
//             else
//             {
//                 if (currentBall.price == 0)
//                 {
//                     buyButtonText.text = currentBall.name + " Free";
//                 }
//                 else
//                 {
//                     buyButtonText.text = "Buy " + currentBall.name + " for " + currentBall.price.ToString() + " Money";
//                 }
//                 buyButton.interactable = true;
//             }
//         }
//         else
//         {
//             Debug.LogError("BuyButtonText or Balls is not assigned or empty in the Inspector");
//         }
//     }

//     public void OnSelectButtonClick()
//     {
//         BallsBlueprint selectedBall = balls[current_ball_index];
//         Debug.Log("Selected Ball: " + selectedBall.name);
//         Debug.Log("Selected Ball SPRITE: " + selectedBall.sprite);


//         if (ownedBalls.Contains(selectedBall.name))
//         {
            
//             SpriteGen.Instance.SetSelectedBall(selectedBall);
//             Debug.Log("Selected Ball: " + selectedBall.sprite);
//         }
//         else
//         {
//             Debug.LogWarning("Ball is not owned or does not exist.");
//         }
//     }

//     public void UpdateDisplayImage()
//     {
//         BallsBlueprint selectedBall = balls[current_ball_index];
//         if (ownedBalls.Contains(selectedBall.name))
//         {
//             Debug.Log("Selected Ball SPRTE: " + selectedBall.sprite);
//             if (selectedBall != null)
//             {
//                 displayImage.sprite = selectedBall.sprite;
//                 Debug.Log("Selected ball SPRITE from store to go is" + selectedBall.sprite);
//             }
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSkin : MonoBehaviour
{
    public GameObject[] skins;
    public int current_ball_index = 0;
    public BallsBlueprint[] balls;
    public Money moneyScript;
    public List<string> ownedBalls = new List<string>();
    public Button buyButton;
    public TextMeshProUGUI buyButtonText;
    public Button selectButton;
    public BallsBlueprint displayImage;
    public TMP_Text crystalText;
    public TMP_Text ballname;
    public CharacterManager obj;

    void Start()
    {
        
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

        UpdateBuyButtonText();

        if (selectButton != null)
        {
            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(OnSelectButtonClick);
        }
        else
        {
            Debug.LogError("Select Button is not assigned in the Inspector");
        }
    }

    void Update()
    {
        crystalText.text = "" + moneyScript.money;
        //name=Getname(current_ball_index);
        

    }

    public void ChangeNext()
    {
       // obj.NextOption();
        Debug.Log("Owned balls are: " + string.Join(", ", ownedBalls));

        skins[current_ball_index].SetActive(false);
        current_ball_index++;
        if (current_ball_index == skins.Length)
            current_ball_index = 0;

        skins[current_ball_index].SetActive(true);

        PlayerPrefs.SetInt("Selected Ball", current_ball_index);
        UpdateBuyButtonText();
        obj.UpdateCharacter(current_ball_index);
        obj.Save();
    }

    public void ChangePrevious()
    {
        
        skins[current_ball_index].SetActive(false);
        current_ball_index--;
        if (current_ball_index == -1)
            current_ball_index = skins.Length - 1;

        skins[current_ball_index].SetActive(true);

        PlayerPrefs.SetInt("Selected Ball", current_ball_index);
        UpdateBuyButtonText();
        obj.UpdateCharacter(current_ball_index);
        obj.Save();
    }

    public void BuyCurrentBallWrapper()
    {
        Debug.Log("BuyCurrentBallWrapper called");
        BuyCurrentBall();
    }

    private void BuyCurrentBall()
    {
        Debug.Log("BuyCurrentBall called");
        Debug.Log("Money is " + moneyScript.money);
        BallsBlueprint currentBall = balls[current_ball_index];

        if (moneyScript != null && moneyScript.GetMoney() >= currentBall.price)
        {
            moneyScript.subtractMoney(currentBall.price);
            Debug.Log("Ball being bought is " + currentBall.name);
            ownedBalls.Add(currentBall.name);
            PlayerPrefs.SetInt(currentBall.name, 1);
            Debug.Log("Bought " + currentBall.name + " for " + currentBall.price);
            UpdateBuyButtonText();
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
        Debug.Log("SELECT BUTTON PRESSED");
        obj.UpdateCharacter(current_ball_index);
        // BallsBlueprint selectedBall = balls[current_ball_index];
        // Debug.Log("Selected Ball: " + selectedBall.name);

        // if (ownedBalls.Contains(selectedBall.name))
        // {
        //     SpriteGen.Instance.SetSelectedBall(selectedBall);
        //     Debug.Log("Selected Ball: " + selectedBall.sprite);
        // }
        // else
        // {
        //     Debug.LogWarning("Ball is not owned or does not exist.");
        // }
    }

    public void UpdateDisplayImage()
    {
        BallsBlueprint selectedBall = balls[current_ball_index];
        if (ownedBalls.Contains(selectedBall.name))
        {
            Debug.Log("Selected Ball SPRTE: " + selectedBall.sprite);
            if (selectedBall != null)
            {
                displayImage.sprite = selectedBall.sprite;
                Debug.Log("Selected ball SPRITE from store to go is" + selectedBall.sprite);
            }
        }
    }
    public bool ReturnBallName(string name)
    {
        if (ownedBalls.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    // public string Getname( int index)
    // {
    //     if (index==0)
    //     {
    //         ballname="Basketball";
    //         return ballname;
    //     }
    // }
}
