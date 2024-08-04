using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;
    //public Text nameText;
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
     public void Load()
    {
        selectedOption=PlayerPrefs.GetInt("selectedOption");
    }
    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        bool flag=bAll.ReturnBallName(character.characterName); // (ownedBalls.Contains(selectedBall.name))
        if (flag==true)
        {
            artworkSprite.sprite=character.characterSprite;
            //nameText.text=character.characterName;

        }
        else
        {
            Debug.Log("Selected ball is not in the owned balls list.");
        }
}


}