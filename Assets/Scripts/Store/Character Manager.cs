using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    public ShowSkin bAll;
    public Button selectButton;
    public int  ball_index;
    public GameObject[] current_skins;
    public List<string> ownedBalls_current;
    public BallsBlueprint check_ball;
    public BallsBlueprint[] ball_list;
    


    public int selectedOption=0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SLECTED OPTION " + selectedOption);
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption=0;

        }
        else
        {
            Load();
        }
       //UpdateCharacter(selectedOption);
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
       //ball_index = bAll.GetCurrentBallIndex(); 
        ball_list=bAll.Getballs();
        //Debug.Log (" Balls when GETBalls " + string.Join(", ", ball_list));
        // Debug.Log("Selection index is " + bAll.GetCurrentBallIndex());
        int index2= bAll.GetCurrentBallIndex();
        string ball_name = ball_list[index2].name;
    
        ownedBalls_current = bAll.GetOwnedBallslist(); 
        Debug.Log("Owned balls are when UPDATE button clicked: " + string.Join(", ", ownedBalls_current));
        if (ownedBalls_current.Contains(ball_name))
        {
            UpdateCharacter(bAll.GetCurrentBallIndex()); // this works!!

        }
        else
        {
            Debug.Log("Curent ball is nto in owned ball lsit");

        }
        
        // Now you can call the method
       /// basically check if currnet ball is in owned list , then not buy else buy and add to owned list . then also save data!. also ened to figure out for money then for sleect button (not imp)
         
        
        
        //UpdateCharacter(selectedOption);


    }
    public void NextOption()
    {
         Debug.Log("Owned balls are: " + string.Join(", ", bAll.ownedBalls));
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption=0;
        }
        //UpdateCharacter(selectedOption);
    }

     public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0 )
        {
            selectedOption= characterDB.CharacterCount-1;
        }
        //UpdateCharacter(selectedOption);
    }
    public void UpdateCharacter(int ball_index)
    {
         
        Character character = characterDB.GetCharacter(ball_index);
        Debug.Log("CHARACTER FOR DISPLAY IS" + character.characterName);
        Debug.Log("CHARACTER SPRITE FOR DISPLAY IS" + character.characterSprite);
        artworkSprite.sprite=character.characterSprite;
         //nameText.text=character.characterName;
         nameText.text=character.characterName;
        //bool flag=bAll.ReturnBallName(character.characterName); // (ownedBalls.Contains(selectedBall.name))
        bool flag=false;
        // Debug.Log(" FLAG IS " + flag);
        // if (flag==false)
        // {
        //     artworkSprite.sprite=character.characterSprite;
           

        // }
        // else
        // {
        //     Debug.Log("Selected ball is not in the owned balls list.");
        // }

    }
    public void Load()
    {
        selectedOption=PlayerPrefs.GetInt("selectedOption");
    }
    public void Save()
    {
        PlayerPrefs.SetInt("selectedOption",selectedOption);
    }

    // Update is called once per frame
    public void OnSelectButtonClick()
    {
        //ball_index=bAll.GetCurrentBallIndex();
        Debug.Log("SELECT CLICKED");

       // Debug.Log("SELECT BUTTON PRESSED, currnet ball index is " +   bAll.current_ball_index );
        UpdateCharacter(bAll.GetCurrentBallIndex());
        //UpdateCharacter(bAll.current_ball_index);
        //Debug.Log("Owned balls are: " + string.Join(", ", bAll.ownedBalls));
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

    // public int GetSelectedOption()
    // {
    //     return 
    // }
  
}
