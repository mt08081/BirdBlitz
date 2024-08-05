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

    private int selectedOption=0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption=0;

        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
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
    public void NextOption()
    {
         Debug.Log("Owned balls are: " + string.Join(", ", bAll.ownedBalls));
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption=0;
        }
        UpdateCharacter(selectedOption);
    }

     public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0 )
        {
            selectedOption= characterDB.CharacterCount-1;
        }
        UpdateCharacter(selectedOption);
    }
    public void UpdateCharacter(int selectedOption)
    {
         
        Character character = characterDB.GetCharacter(selectedOption);
        Debug.Log("CHARACTER FOR DISPLAY IS" + character.characterName);
        Debug.Log("CHARACTER SPRITE FOR DISPLAY IS" + character.characterSprite);
        artworkSprite.sprite=character.characterSprite;
         //nameText.text=character.characterName;
         nameText.text=character.characterName;
        bool flag=bAll.ReturnBallName(character.characterName); // (ownedBalls.Contains(selectedBall.name))
        Debug.Log(" FLAG IS " + flag);
        if (flag==false)
        {
            artworkSprite.sprite=character.characterSprite;
           

        }
        else
        {
            Debug.Log("Selected ball is not in the owned balls list.");
        }

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
        Debug.Log("SELECT BUTTON PRESSED");
        UpdateCharacter(0);
        //UpdateCharacter(bAll.current_ball_index);
        Debug.Log("Owned balls are: " + string.Join(", ", bAll.ownedBalls));
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
  
}
