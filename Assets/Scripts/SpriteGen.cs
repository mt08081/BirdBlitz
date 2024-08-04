// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpriteGen : MonoBehaviour
// {
//     public static SpriteGen Instance;
//     public BallsBlueprint selectedBall;
//     public Sprite sprite;
//     public SpriteRenderer spriteRenderer; // this was Sprite Renderer
    

//     void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//            // Destroy(gameObject);
//         }
//     }

//     void Start()
//     {
//        // spriteRenderer = GetComponent<SpriteGen>();
//         //UpdateSprite();
//     }

//     void Update()
//     {
//         // Ensure the sprite is always up-to-date
//        // UpdateSprite();
//     }

//     public void SetSelectedBall(BallsBlueprint ball)
//     {
//         selectedBall.sprite = ball.sprite;
//         Debug.Log("IN SETSELECTEDBALL the sprite is " +  selectedBall.sprite);
//        // UpdateDisplayImage();
//         //UpdateSprite();
//     }

//     public BallsBlueprint GetSelectedBall()
//     {
//         return selectedBall;
//     }

//     // private void UpdateSprite()
//     // {
//     //     if (selectedBall != null && spriteRenderer != null)
//     //     {
//     //         Debug.Log("Sprite Renderer sprite  is " + spriteRenderer.sprite );
//     //         Debug.Log("Select ball sprite is +" + selectedBall.sprite);
//     //         spriteRenderer.sprite = selectedBall.sprite;
//     //     }
//     // }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SpriteGen : MonoBehaviour
{
    public static SpriteGen Instance;
    public BallsBlueprint selectedBall;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
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

    void Start()
    {
        // Ensure the spriteRenderer is assigned
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        // Ensure the sprite is always up-to-date
        //UpdateSprite();
    }

    public void SetSelectedBall(BallsBlueprint ball)
    {
        selectedBall = ball;
        Debug.Log("IN SETSELECTEDBALL the sprite is " + selectedBall.sprite);
        UpdateSprite();
    }

    public BallsBlueprint GetSelectedBall()
    {
        return selectedBall;
    }

    private void UpdateSprite()
    {
        if (selectedBall != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = selectedBall.sprite;
            Debug.Log("Sprite Renderer sprite is updated to " + spriteRenderer.sprite);
        }
    }
}
