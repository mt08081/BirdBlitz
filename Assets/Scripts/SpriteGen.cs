using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGen : MonoBehaviour
{
    public static SpriteGen Instance;
    public BallsBlueprint selectedBall;
    public Sprite sprite;
    private SpriteGen spriteRenderer;
    //Start is called before the first frame update
    void Start()
    {
        Debug.Log(" Selected ball from store is" + selectedBall.name);
        spriteRenderer = GetComponent<SpriteGen>();
        spriteRenderer.sprite = selectedBall.sprite;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" Selected ball from store is" + selectedBall.name);
        spriteRenderer = GetComponent<SpriteGen>();
        spriteRenderer.sprite = selectedBall.sprite;
        Debug.Log(" Selected ball SPRITE  from store is" + selectedBall.sprite);
        
    }
     public void SetSelectedBall(BallsBlueprint ball)
    {
        selectedBall = ball;
    }

    public BallsBlueprint GetSelectedBall()
    {
        return selectedBall;
    }
}
