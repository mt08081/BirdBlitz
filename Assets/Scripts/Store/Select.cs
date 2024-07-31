using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Select : ScriptableObject
{
    // Start is called before the first frame update
    public BallsBlueprint[] character;
    public string ball_name2;

    public BallsBlueprint GetCharacter (int index)
    {
        return character[index];
    }

}
