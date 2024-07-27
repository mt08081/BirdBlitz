// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class showskin : MonoBehaviour
// // {
// //     public GameObject[] skins;
// //     public int current_ball_index=;
    
// //     // Start is called before the first frame update
// //     void Start()
// //     {
// //         current_ball_index= PlayerPrefs.GetInt("Selected Ball",0);
// //         foreach(GameObject ball in skins)
// //             ball.SetActive(false);
        
// //         skins[current_ball_index].SetActive(true);


        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// //     public void ChangeNext()
// //     {
// //         skins[current_ball_index].SetActive(false);
// //         current_ball_index++;
// //         if(current_ball_index==skins.Length)
// //             current_ball_index=0;
// //         skins[current_ball_index].SetActive(true);
// //         current_ball_index= PlayerPrefs.SetInt("Selected Ball",current_ball_index);

        

// //     }
// // }

// // part 2
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class showskin : MonoBehaviour
// {
//     public GameObject[] skins;
//     public int current_ball_index = 0;  // Initialize to 0 or any other default value
//     public BallsBlueprint[] balls;
//     public Money moneyScript;
//     public List<balls> ballList;  // List of balls with their prices
//     public List<string> ownedBalls;  // List of owned balls
//     public Button buyButton;
//     public TextMeshProUGUI buyButtonText;
//     //private int current_ball_index = 0;
//     //public  Button buyButton;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         foreach(BallsBlueprint ball in balls)
//         {
//             if (ball.price==0)
//             ball.unlocked=true;
//             else
//             ball.unlocked= PlayerPrefs.GetInt(ball.name,0)==0? false:true;


//         }

//         current_ball_index = PlayerPrefs.GetInt("Selected Ball", 0);
//         foreach(GameObject ball in skins)
//             ball.SetActive(false);
        
//         skins[current_ball_index].SetActive(true);
//         if (buyButton != null)
//         {
//             buyButton.onClick.AddListener(BuyCurrentBall);
//         }
//         else
//         {
//             Debug.LogError("Buy Button is not assigned in the Inspector");
//         }

//         UpdateBuyButtonText(); // Initialize the buy button text
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
    
//     public void ChangeNext()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index++;
//         if (current_ball_index == skins.Length)
//             current_ball_index = 0;
        
//         skins[current_ball_index].SetActive(true);
        
//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//     }
//     public void ChangePrevious()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index--;
//         if (current_ball_index == -1)
//             current_ball_index =skins.Length-1;
        
//         skins[current_ball_index].SetActive(true);
        
//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//     }
//      public void BuyCurrentBall()
//     {
//         public balls currentBall = ballList[current_ball_index];

//         if (moneyScript != null && moneyScript.money >= currentBall.price)
//         {
//             moneyScript.subtractMoney(currentBall.price);
//             ownedBalls.Add(currentBall.ballName);
//             Debug.Log("Bought " + currentBall.ballName + " for " + currentBall.price);
//             UpdateBuyButtonText();  // Update the button text and state after purchase
//         }
//         else
//         {
//             Debug.Log("Not enough money to buy " + currentBall.ballName);
//         }
//     }
//      void UpdateBuyButtonText()
//     {
//         if (buyButtonText != null && ballList != null && ballList.Count > 0)
//         {
//             public balls currentBall = ballList[current_ball_index];
//             buyButtonText.text = "Buy " + currentBall.ballName + " for " + currentBall.price.ToString() + " Money";

//             if (ownedBalls.Contains(currentBall.ballName))
//             {
//                 buyButton.interactable = false;
//                 buyButtonText.text = currentBall.ballName + " already owned";
//             }
//             else
//             {
//                 buyButton.interactable = true;
//             }
//         }
//         else
//         {
//             Debug.LogError("BuyButtonText or BallList is not assigned or empty in the Inspector");
//         }
//     }
//     public void ShowNextBall()
//     {
//         current_ball_index = (current_ball_index + 1) % ballList.Count;
//         UpdateBuyButtonText();
//     }

//     public void ShowPreviousBall()
//     {
//         current_ball_index = (current_ball_index - 1 + ballList.Count) % ballList.Count;
//         UpdateBuyButtonText();
//     }

    
// }

// some errors fixed below:


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ShowSkin : MonoBehaviour
// {
//     public GameObject[] skins;
//     public int current_ball_index = 0;  // Initialize to 0 or any other default value
//     public BallsBlueprint[] balls;
//     public Money moneyScript;
//     public List<BallsBlueprint> ballList;  // List of balls with their prices
//     public List<string> ownedBalls;  // List of owned balls
//     public Button buyButton;
//     public TextMeshProUGUI buyButtonText;

//     void Start()
//     {
//         // Ensure the first ball is unlocked
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

//         if (buyButton != null)
//         {
//             buyButton.onClick.AddListener(BuyCurrentBall);
//         }
//         else
//         {
//             Debug.LogError("Buy Button is not assigned in the Inspector");
//         }

//         UpdateBuyButtonText(); // Initialize the buy button text
//     }

//     void Update()
//     {
//         // You can remove the Update method if it's not being used.
//     }

//     public void ChangeNext()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index++;
//         if (current_ball_index == skins.Length)
//             current_ball_index = 0;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//         UpdateBuyButtonText();
//     }

//     public void ChangePrevious()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index--;
//         if (current_ball_index == -1)
//             current_ball_index = skins.Length - 1;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//         UpdateBuyButtonText();
//     }

//     public void BuyCurrentBall()
//     {
//         BallsBlueprint currentBall = ballList[current_ball_index];

//         if (moneyScript != null && moneyScript.GetMoney() >= currentBall.price)
//         {
//             moneyScript.subtractMoney(currentBall.price);
//             ownedBalls.Add(currentBall.name);
//             PlayerPrefs.SetInt(currentBall.name, 1); // Mark as owned
//             Debug.Log("Bought " + currentBall.name + " for " + currentBall.price);
//             UpdateBuyButtonText();  // Update the button text and state after purchase
//         }
//         else
//         {
//             Debug.Log("Not enough money to buy " + currentBall.name);
//         }
//     }

//     public void UpdateBuyButtonText()
//     {
//         if (buyButtonText != null && ballList != null && ballList.Count > 0)
//         {
//             BallsBlueprint currentBall = ballList[current_ball_index];
//             if (ownedBalls.Contains(currentBall.name))
//             {
//                 buyButton.interactable = false;
//                 buyButtonText.text = currentBall.name + " already owned";
//             }
//             else
//             {
//                 buyButtonText.text = "Buy " + currentBall.name + " for " + currentBall.price.ToString() + " Money";
//                 buyButton.interactable = true;
//             }
//         }
//         else
//         {
//             Debug.LogError("BuyButtonText or BallList is not assigned or empty in the Inspector");
//         }
//     }

//     public void ShowNextBall()
//     {
//         current_ball_index = (current_ball_index + 1) % ballList.Count;
//         UpdateBuyButtonText();
//     }

//     public void ShowPreviousBall()
//     {
//         current_ball_index = (current_ball_index - 1 + ballList.Count) % ballList.Count;
//         UpdateBuyButtonText();
//     }
// }

// still not working:

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ShowSkin : MonoBehaviour
// {
//     public GameObject[] skins;
//     public int current_ball_index = 0;  // Initialize to 0 or any other default value
//     public BallsBlueprint[] balls;
//     public Money moneyScript;
//     public List<BallsBlueprint> ballList;  // List of balls with their prices
//     public List<string> ownedBalls;  // List of owned balls
//     public Button buyButton;
//     public TextMeshProUGUI buyButtonText;

//     void Start()
//     {
//         // Ensure the first ball is unlocked
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

//         if (buyButton != null)
//         {
//             buyButton.onClick.AddListener(BuyCurrentBallWrapper);
//         }
//         else
//         {
//             Debug.LogError("Buy Button is not assigned in the Inspector");
//         }

//         UpdateBuyButtonText(); // Initialize the buy button text
//     }

//     void Update()
//     {
//         // You can remove the Update method if it's not being used.
//     }

//     public void ChangeNext()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index++;
//         if (current_ball_index == skins.Length)
//             current_ball_index = 0;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//         UpdateBuyButtonText();
//     }

//     public void ChangePrevious()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index--;
//         if (current_ball_index == -1)
//             current_ball_index = skins.Length - 1;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//         UpdateBuyButtonText();
//     }

//     // This wrapper method is necessary for Unity to see it in the Inspector
//     public void BuyCurrentBallWrapper()
//     {
//         BuyCurrentBall();
//     }

//     private void BuyCurrentBall()
//     {
//         BallsBlueprint currentBall = ballList[current_ball_index];
//         //Debug.Log("IT WORKS");
//         Debug.Log("Money is "+ moneyScript.GetMoney());
//         if (moneyScript != null && moneyScript.GetMoney() >= currentBall.price)
//         {
//             moneyScript.subtractMoney(currentBall.price);
//             ownedBalls.Add(currentBall.name);
//             PlayerPrefs.SetInt(currentBall.name, 1); // Mark as owned
//             Debug.Log("Bought " + currentBall.name + " for " + currentBall.price);
//             UpdateBuyButtonText();  // Update the button text and state after purchase
//         }
//         else
//         {
//             Debug.Log("Not enough money to buy " + currentBall.name);
//         }
//     }

//     void UpdateBuyButtonText()
//     {
//         if (buyButtonText != null && ballList != null && ballList.Count > 0)
//         {
//             BallsBlueprint currentBall = ballList[current_ball_index];
//             if (ownedBalls.Contains(currentBall.name))
//             {
//                 buyButton.interactable = false;
//                 buyButtonText.text = currentBall.name + " already owned";
//             }
//             else
//             {
//                 buyButtonText.text = "Buy " + currentBall.name + " for " + currentBall.price.ToString() + " Money";
//                 buyButton.interactable = true;
//             }
//         }
//         else
//         {
//             Debug.LogError("BuyButtonText or BallList is not assigned or empty in the Inspector");
//         }
//     }

//     public void ShowNextBall()
//     {
//         current_ball_index = (current_ball_index + 1) % ballList.Count;
//         UpdateBuyButtonText();
//     }

//     public void ShowPreviousBall()
//     {
//         current_ball_index = (current_ball_index - 1 + ballList.Count) % ballList.Count;
//         UpdateBuyButtonText();
//     }
// }


// updated logic using change next + change prev

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ShowSkin : MonoBehaviour
// {
//     public GameObject[] skins;
//     public int current_ball_index = 0;  // Initialize to 0 or any other default value
//     public BallsBlueprint[] balls;
//     public Money moneyScript;
//     public List<BallsBlueprint> ballList;  // List of balls with their prices
//     public List<string> ownedBalls = new List<string>();  // List of owned balls
//     public Button buyButton;
//     public TextMeshProUGUI buyButtonText;

//     void Start()
//     {
//         // Ensure the first ball is unlocked
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

//         if (buyButton != null)
//         {
//             buyButton.onClick.AddListener(BuyCurrentBallWrapper);
//         }
//         else
//         {
//             Debug.LogError("Buy Button is not assigned in the Inspector");
//         }

//         UpdateBuyButtonText(); // Initialize the buy button text
//         //ballList=["BasketBall","BeachBall","FootBall"];
//     }

//     public void ChangeNext()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index++;
//         if (current_ball_index == skins.Length)
//             current_ball_index = 0;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//         UpdateBuyButtonText();
//     }

//     public void ChangePrevious()
//     {
//         skins[current_ball_index].SetActive(false);
//         current_ball_index--;
//         if (current_ball_index == -1)
//             current_ball_index = skins.Length - 1;

//         skins[current_ball_index].SetActive(true);

//         PlayerPrefs.SetInt("Selected Ball", current_ball_index);  // Set the PlayerPrefs without assigning
//         UpdateBuyButtonText();
//     }

//     // This wrapper method is necessary for Unity to see it in the Inspector
//     public void BuyCurrentBallWrapper()
//     {
//         BuyCurrentBall();
//     }

//     private void BuyCurrentBall()
//     {
//         BallsBlueprint currentBall = ballList[current_ball_index];

//         if (moneyScript != null && moneyScript.GetMoney() >= currentBall.price)
//         {
//             moneyScript.subtractMoney(currentBall.price);
//             ownedBalls.Add(currentBall.name);
//             PlayerPrefs.SetInt(currentBall.name, 1); // Mark as owned
//             Debug.Log("Bought " + currentBall.name + " for " + currentBall.price);
//             UpdateBuyButtonText();  // Update the button text and state after purchase
//         }
//         else
//         {
//             Debug.Log("Not enough money to buy " + currentBall.name);
//         }
//     }

//     void UpdateBuyButtonText()
//     {
//         if (buyButtonText != null && ballList != null && ballList.Count > 0)
//         {
//             BallsBlueprint currentBall = ballList[current_ball_index];
//             if (ownedBalls.Contains(currentBall.name) || currentBall.unlocked)
//             {
//                 buyButton.interactable = false;
//                 buyButtonText.text = currentBall.name + " already owned";
//             }
//             else
//             {
//                 buyButtonText.text = "Buy " + currentBall.name + " for " + currentBall.price.ToString() + " Money";
//                 buyButton.interactable = true;
//             }
//         }
//         else
//         {
//             Debug.LogError("BuyButtonText or BallList is not assigned or empty in the Inspector");
//         }
//     }

//     public void ShowNextBall()
//     {
//         ChangeNext();  // Use ChangeNext method
//     }

//     public void ShowPreviousBall()
//     {
//         ChangePrevious();  // Use ChangePrevious method
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
    public int current_ball_index = 0;  // Initialize to 0 or any other default value
    public BallsBlueprint[] balls;
    public Money moneyScript;
    //public int moneyScript.money;
    public List<string> ownedBalls = new List<string>();  // List of owned balls
    public Button buyButton;
    public TextMeshProUGUI buyButtonText;

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
}
