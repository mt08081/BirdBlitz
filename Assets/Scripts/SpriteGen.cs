using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void Update()
    {
        // Ensure the sprite is always up-to-date
        UpdateSprite();
    }

    public void SetSelectedBall(BallsBlueprint ball)
    {
        selectedBall = ball;
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
        }
    }
}
