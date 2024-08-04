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
        
    }
    public void NextOption()
    {
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
         nameText.text=character.characterName;
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
  
}
