using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
   
    // Start is called before the first frame update
   public Character[] character;
   public int CharacterCount
   {
    get{
        return character.Length;
    }
   }
   public Character GetCharacter(int index)
   {
    return character[index];
   }
}
