using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ball", menuName = "Balls/Ball")]
public class Select : ScriptableObject
{
    // Start is called before the first frame update
    public BallsBlueprint[] character;
    public BallsBlueprint[] balls;
    public string ball_name2;
    public Sprite ballSprite;
    public int price2;

    public BallsBlueprint GetCharacter (int index)
    {
        return character[index];
    }
    public BallsBlueprint GetBall(int index)
    {
        if (index >= 0 && index < balls.Length)
        {
            return balls[index];
        }
        return null;
    }

}
