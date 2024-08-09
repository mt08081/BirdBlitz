// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.UI;
// // using TMPro;

// // public class Money : MonoBehaviour
// // {
// //     public Button add_money;
// //     public TextMeshProUGUI moneyText;
// //     int money;
// //     // Start is called before the first frame update
// //     void Start()
// //     {
// //         money=0;
// //         add_money.onclick(addMoney(30));
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// //     public void addMoney(int money_to_add)
// //     {
// //         money+=money_to_add;
// //         UpdateMoneyText();
// //     }
// //     public void subtractMoney(int money_to_subtract)
// //     {
// //         money-=money_to_subtract;
// //     }
// //     void UpdateMoneyText()
// //     {
// //         if (moneyText != null)
// //         {
// //             moneyText.text = "Money: " + money.ToString();
// //         }
// //         else
// //         {
// //             Debug.LogError("MoneyText is not assigned in the Inspector");
// //         }
// // }

// // fixed:

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class Money : MonoBehaviour
// {
//     public Button add_money;
//     public TextMeshProUGUI moneyText;
//     public Button subtract_money;
//     public BallsBlueprint ball;
    

//     int money;

//     // Start is called before the first frame update
//     void Start()
//     {
//         money = 0;
//         if (add_money != null)
//         {
//             add_money.onClick.AddListener(() => addMoney(30));
//         }
//         else
//         {
//             Debug.LogError("Add Money button is not assigned in the Inspector");
//         }
//         UpdateMoneyText(); // Initialize the money text at the start
//          if (subtract_money != null)
//         {
//             subtract_money.onClick.AddListener(() => subtractMoney(ball.price));
//         }
//         else
//         {
//             Debug.LogError("Add Money button is not assigned in the Inspector");
//         }
//         UpdateMoneyText(); // Initialize the money text at the start

        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // You can remove the Update method if it's not being used.
//     }

//     public void addMoney(int money_to_add)
//     {
//         money += money_to_add;
//         UpdateMoneyText();
//     }

//     public void subtractMoney(int money_to_subtract)
//     {
//         money -= money_to_subtract;
//         UpdateMoneyText(); // Update the money text after subtracting money
//     }

//     void UpdateMoneyText()
//     {
//         if (moneyText != null)
//         {
//             moneyText.text = "Money: " + money.ToString();
//         }
//         else
//         {
//             Debug.LogError("MoneyText is not assigned in the Inspector");
//         }
//     }
// }

 
 // some compilation errors fixed below:
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class Money : MonoBehaviour
// {
//     public Button add_money;
//     public TextMeshProUGUI moneyText;
//     public int money;

//     void Start()
//     {
//         money = 0;
//         if (add_money != null)
//         {
//             add_money.onClick.AddListener(() => addMoney(30));
//             Debug.Log("Money added" + money);
//         }
//         else
//         {
//             Debug.LogError("Add Money button is not assigned in the Inspector");
//         }
//         UpdateMoneyText(); // Initialize the money text at the start
//     }

//     void Update()
//     {
       
//     }

//     public void addMoney(int money_to_add)
//     {
//         money += money_to_add;
//         UpdateMoneyText();
//     }

//     public void subtractMoney(int money_to_subtract)
//     {
//         money -= money_to_subtract;
//         UpdateMoneyText(); // Update the money text after subtracting money
//     }

//     public int GetMoney()
//     {
//         return money;
//     }

//     void UpdateMoneyText()
//     {
//         if (moneyText != null)
//         {
//             moneyText.text = "Money: " + money.ToString();
//         }
//         else
//         {
//             Debug.LogError("MoneyText is not assigned in the Inspector");
//         }
//     }
// }


// updated logic incorporated with change next + prev

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public Button add_money;
    public TextMeshProUGUI moneyText;
    public Button subtract_money;

    public int money;

    void Start()
    {
       money = PlayerPrefs.GetInt("Money", 1000);
        if (add_money != null)
        {
            add_money.onClick.AddListener(() => addMoney(30));
        }
        else
        {
            Debug.LogError("Add Money button is not assigned in the Inspector");
        }
        void Update()
        {
            UpdateMoneyText();
        }

        UpdateMoneyText(); // Initialize the money text at the start

        if (subtract_money != null)
        {
            subtract_money.onClick.AddListener(() => subtractMoney(10)); // Example subtraction amount
        }
        else
        {
            Debug.LogError("Subtract Money button is not assigned in the Inspector");
        }

        UpdateMoneyText(); // Initialize the money text at the start
    }

    public void addMoney(int money_to_add)
    {
        money += money_to_add;
        Debug.Log("Money uppon add  is" + money);
        SaveMoney();
        UpdateMoneyText();
    }

    public void subtractMoney(int money_to_subtract)
    {
        money -= money_to_subtract;
        UpdateMoneyText(); // Update the money text after subtracting money
        SaveMoney();
    }

    public int GetMoney()
    {
        return money;
    }

    void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: " + money.ToString();
        }
        else
        {
            Debug.LogError("MoneyText is not assigned in the Inspector");
        }
    }
    void SaveMoney()

    {

        PlayerPrefs.SetInt("Money", money);

        PlayerPrefs.Save();

    }



    void OnApplicationQuit()

    {

        SaveMoney(); // Ensure money is saved when the application is closed

    }
}
